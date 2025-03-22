using UnityEngine;

public class isometricCameraPanner : MonoBehaviour
{
    public float panSpeed = 6f;
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
        Vector2 panPosition = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));

        transform.position += Quaternion.Euler(x: 0, y: _camera.transform.eulerAngles.y, z: 0) * new Vector3(panPosition.x, y: 0, z: panPosition.y) * (panSpeed * Time.deltaTime);
    }
}
