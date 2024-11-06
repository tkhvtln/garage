using System.Linq;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform[] _trSlots;

    public void PutItem(Item item)
    {
        Transform emptySlot = _trSlots.FirstOrDefault(slot => slot.childCount < 1);
        if (emptySlot != null)
        {
            item.SetLayerMask(Constants.LAYER_MASK_DEFAULT);

            item.transform.parent = emptySlot;
            item.transform.position = emptySlot.position;
            item.transform.localRotation = emptySlot.localRotation;
        }
    }
}
