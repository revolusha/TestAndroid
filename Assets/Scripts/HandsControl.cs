using UnityEngine;

public class HandsControl : MonoBehaviour
{
    [SerializeField] private Transform _pivot;

    public void TakeItem(GameObject item)
    {
        item.transform.parent = _pivot;
        item.transform.localPosition = Vector3.zero;
    }
}