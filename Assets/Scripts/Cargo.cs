using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private Transform[] _itemSpots;

    private GameObject[] _items;

    private void Start()
    {
        _items = new GameObject[_itemSpots.Length];
    }

    public void TryPlaceItem(GameObject item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null)
            {
                _items[i] = item;
                item.transform.parent = _itemSpots[i];
                item.transform.localPosition = Vector3.zero;

                return;
            }
        }

        Debug.Log("Not Enough Space For Item!");
    }
}