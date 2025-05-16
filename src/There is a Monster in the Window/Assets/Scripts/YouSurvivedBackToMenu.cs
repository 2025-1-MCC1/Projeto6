using System.Collections;
using UnityEngine;

public class YouSurvivedBackToMenu : MonoBehaviour
{
    public GameObject meuBotao; // Arraste o bot�o aqui pelo Inspector

    void Start()
    {
        meuBotao.gameObject.SetActive(false); // Garante que come�a desativado
        StartCoroutine(EsperarEAbrir());
    }

    IEnumerator EsperarEAbrir()
    {
        yield return new WaitForSeconds(20f); // Espera 1 minuto

        // Ativa o bot�o
        meuBotao.gameObject.SetActive(true);

        // Desbloqueia o cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
