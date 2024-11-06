using System.Linq;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public ItemListConfig itemListConfig;
    [SerializeField] private Transform[] _trSlots;

    public void SpawnItem(int index)
    {
        Transform emptySlot = _trSlots.FirstOrDefault(slot => slot.childCount < 1);
        if (emptySlot != null)
            Instantiate(itemListConfig.items[index], emptySlot.position, emptySlot.rotation, emptySlot);
    }

    public void RemoveLastItem()
    {
        Transform fullSlot = _trSlots.Reverse().FirstOrDefault(slot => slot.childCount > 0);
        if (fullSlot != null)
            DestroyImmediate(fullSlot.GetChild(0).gameObject);  
    }

    public void RemoveAllItems()
    {
        foreach (Transform slot in _trSlots)
            if (slot.childCount > 0)
                DestroyImmediate(slot.GetChild(0).gameObject);
    }
}
