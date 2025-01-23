using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivity = 300;
    [SerializeField] private int _raycastLayer = 7;
    [SerializeField] private float _raycastDistance = 2;

    private float _rotationX;

    private void Start()
    {
        InputHandler.OnHit += CastHitRay;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        InputHandler.OnHit -= CastHitRay;
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _player.Rotate(Vector3.up * inputX);
        _rotationX -= inputY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90);

        transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }

    private void CastHitRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, _raycastDistance, _raycastLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

}