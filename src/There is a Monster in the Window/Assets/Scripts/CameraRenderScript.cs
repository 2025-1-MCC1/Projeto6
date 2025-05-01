using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraRenderScript : MonoBehaviour
{
    // Não estou achando no Inspector o ''Target Texture'' para colocar a render da camera, tentando pelo script:

    public RenderTexture renderTexture; 
    void Start()
    {
        Camera camera = GetComponent<Camera>(); // get component ''busca'' o objeto/componente que quero
        if (camera != null && renderTexture != null)
        {
            camera.targetTexture = renderTexture; //para definir a RenderTexture da camera como o target
        }
        else
        {
            Debug.LogError("Não encontrei"); //testando essa linha e para que serve 
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
