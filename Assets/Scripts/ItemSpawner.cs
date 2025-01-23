using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _itemPrefabs;
    [SerializeField] private Material[] _colorMaterials;

    private void Start()
    {
        GenerateItems();
    }

    private void GenerateItems()
    {
        int randomItemIndex;
        List<Material> randomMaterial = new();
        int randomColorIndex;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            randomItemIndex = UnityEngine.Random.Range(0, _itemPrefabs.Length);
            randomColorIndex = UnityEngine.Random.Range(0, _colorMaterials.Length);

            GameObject newItem = Instantiate(_itemPrefabs[randomItemIndex], _spawnPoints[i]);

            randomMaterial.Add(_colorMaterials[randomColorIndex]);
            newItem.GetComponent<MeshRenderer>().SetMaterials(randomMaterial);
            randomMaterial.Clear();
        }
    }
}
