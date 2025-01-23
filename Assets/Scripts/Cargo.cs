using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private Transform[] _itemSpots;

    private void Start()
    {
        HandsControl.OnReadyToGiveItem += TryPlaceItem;
    }

    private void OnDisable()
    {
        HandsControl.OnReadyToGiveItem -= TryPlaceItem;
    }

    public void TryPlaceItem(GameObject item)
    {
        for (int i = 0; i < _itemSpots.Length; i++)
        {
            if (_itemSpots[i].childCount == 0)
            {
                item.transform.parent = _itemSpots[i];
                item.transform.localPosition = Vector3.zero;

                return;
            }
        }

        Debug.Log("Not Enough Space For Item!");
    }
}