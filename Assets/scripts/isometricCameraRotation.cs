using UnityEngine;
using UnityEngine.UIElements;

public class isometricCameraRotation : MonoBehaviour
{
    public float rotationSpeed = 300f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseDeltaX = Input.GetAxis("Mouse X");

            transform.Rotate(Vector3.up, angle: mouseDeltaX *  rotationSpeed * Time.deltaTime);
        }
        
    }
}
