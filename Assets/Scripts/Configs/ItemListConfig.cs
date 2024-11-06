using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Configs/ItemList")]
public class ItemListConfig : ScriptableObject
{
    public Item[] items;
}
