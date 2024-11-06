using UnityEngine;

public class Item : MonoBehaviour
{
    public void SetLayerMask(string name)
    {
        foreach (Transform tr in transform)
            tr.gameObject.layer = LayerMask.NameToLayer(name);
    }
}
