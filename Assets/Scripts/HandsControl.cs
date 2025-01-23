using System;
using UnityEngine;

public class HandsControl : MonoBehaviour
{
    [SerializeField] private Transform _pivot;

    public static Action<GameObject> OnReadyToGiveItem;

    private GameObject _item;

    private void Start()
    {
        CameraControl.OnRaycastHitItem += TryTakeItem;
        CameraControl.OnRaycastHitCar += TryPlaceItem;
    }

    private void OnDisable()
    {
        CameraControl.OnRaycastHitItem -= TryTakeItem;
        CameraControl.OnRaycastHitCar -= TryPlaceItem;
    }

    private void TryTakeItem(GameObject item)
    {
        if (_pivot.childCount == 0)
        {
            _item = item;
            _item.transform.parent = _pivot;
            _item.transform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("Hands Are Already Full!");
        }
    }

    private void TryPlaceItem()
    {
        if (_pivot.childCount > 0)
        { 
            OnReadyToGiveItem?.Invoke(_item);
        }
        else
        {
            Debug.Log("Hands Are Empty!");
        }

    }
}