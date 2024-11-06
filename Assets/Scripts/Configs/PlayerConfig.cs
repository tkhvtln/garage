using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Configs/Player")]
public class PlayerConfig : ScriptableObject
{
    public float speedWalk => _speedWalk;
    public float speedRotate => _speedRotate;
    public float distanceInteract => _distanceInteract;

    [SerializeField, Min(0)] private float _speedWalk = 1;
    [SerializeField, Min(0)] private float _speedRotate = 1;
    [SerializeField, Min(0)] private float _distanceInteract = 1;
}
