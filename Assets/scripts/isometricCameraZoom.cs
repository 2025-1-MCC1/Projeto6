using UnityEngine;

public class isometricCameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10;
    public float zoomSmoothness = 5;

    public float minZoom = 2;
    public float maxZoom = 8.2f;

    private float _currentZoom;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentZoom = Mathf.Clamp(value: _currentZoom - Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
        _camera.orthographicSize = Mathf.Lerp(a: _camera.orthographicSize, b: _currentZoom, t: zoomSmoothness * Time.deltaTime);
        
    }
}
