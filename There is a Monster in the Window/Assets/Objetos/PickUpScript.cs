using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que permite ao jogador pegar, soltar, girar e arremessar objetos
public class PickUpScript : MonoBehaviour
{
    public GameObject player; // Referência ao GameObject do jogador
    public Transform holdPos; // Posição onde o objeto será segurado

    public float throwForce = 500f; // Força com que o objeto será arremessado
    public float pickUpRange = 5f; // Distância máxima para pegar um objeto
    private float rotationSensitivity = 2f; // Sensibilidade da rotação com o mouse
    private GameObject heldObj; // Objeto atualmente segurado
    private Rigidbody heldObjRb; // Rigidbody do objeto segurado
    private bool canDrop = true; // Se o jogador pode soltar/arremessar o objeto no momento
    private int LayerNumber; // Índice da camada de layer usada quando segurando o objeto

    private StarterAssets.StarterAssetsInputs playerInputs; // Referência ao sistema de entrada do Starter Assets

    void Start()
    {
        // Armazena o número da layer usada para o objeto segurado
        LayerNumber = LayerMask.NameToLayer("holdLayer");

        // Obtém o componente de entrada do jogador
        playerInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    void Update()
    {
        // Pressionar E para pegar ou soltar o objeto
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                // Faz um Raycast para checar se há um objeto na frente para pegar
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    // Verifica se o objeto tem a tag correta
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        PickUpObject(hit.transform.gameObject); // Pega o objeto
                    }
                }
            }
            else
            {
                if (canDrop)
                {
                    StopClipping(); // Evita que o objeto clippe com paredes
                    DropObject();   // Solta o objeto
                }
            }
        }

        if (heldObj != null)
        {
            MoveObject();   // Mantém o objeto na posição de segurar
            RotateObject(); // Permite rotacionar o objeto

            // Se o botão esquerdo do mouse for pressionado e puder soltar
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop)
            {
                StopClipping();
                ThrowObject(); // Arremessa o objeto
            }
        }
    }

    // Função para pegar o objeto
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true; // Desativa física
            heldObjRb.transform.parent = holdPos.transform; // "Gruda" o objeto na posição de segurar
            heldObj.layer = LayerNumber; // Coloca na layer de segurar
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true); // Evita colisão com o jogador
        }
    }

    // Função para soltar o objeto
    void DropObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false); // Reativa colisão
        heldObj.layer = 0; // Volta para a layer padrão
        heldObjRb.isKinematic = false; // Reativa física
        heldObj.transform.parent = null; // Remove da posição de segurar
        heldObj = null;
    }

    // Move o objeto junto com a posição de segurar
    void MoveObject()
    {
        heldObj.transform.position = holdPos.transform.position;
    }

    // Permite rotacionar o objeto com o mouse ao segurar R
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            canDrop = false; // Não pode soltar enquanto gira

            // Congela o movimento da câmera
            playerInputs.look = Vector2.zero;
            playerInputs.cursorInputForLook = false;

            // Usa o movimento do mouse para rotacionar o objeto
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;

            heldObj.transform.Rotate(Vector3.up, XaxisRotation);
            heldObj.transform.Rotate(Vector3.left, YaxisRotation);
        }
        else
        {
            // Reativa controle de câmera e permite soltar
            playerInputs.cursorInputForLook = true;
            canDrop = true;
        }
    }

    // Arremessa o objeto com força
    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce); // Aplica força na direção do jogador
        heldObj = null;
    }

    // Garante que o objeto não clippe com algo quando soltar ou arremessar
    void StopClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);

        // Usa RaycastAll para verificar todos os objetos entre a câmera e o objeto segurado
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            // Reposiciona o objeto mais perto do jogador, com um leve deslocamento para baixo
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
    }
}
