using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensitivity = 300;
    [SerializeField] private int _raycastItemLayerIndex = 7;
    [SerializeField] private int _raycastCarLayerIndex = 8;
    [SerializeField] private float _raycastDistance = 2;

    public static Action<GameObject> OnRaycastHitItem;
    public static Action OnRaycastHitCar;

    private float _rotationX;
    private int _raycastLayer;

    private void Start()
    {
        InputHandler.OnHit += CastHitRay;
        Cursor.lockState = CursorLockMode.Locked;
        _raycastLayer = (1 << _raycastItemLayerIndex) | (1 << _raycastCarLayerIndex);
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
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.GetComponentInChildren<Cargo>() != null)
            {
                OnRaycastHitCar?.Invoke();

                return;
            }

            OnRaycastHitItem?.Invoke(hitObject);

            return;
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}