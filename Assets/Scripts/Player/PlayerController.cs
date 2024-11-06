using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerInteractive))]

public class PlayerController : MonoBehaviour
{
    public PlayerConfig config => _config;

    [SerializeField] private PlayerConfig _config;

    private InputPlayer _inputPlayer;
    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;

    [Inject]
    private void Construct(InputPlayer inputPlayer)
    {
        _inputPlayer = inputPlayer;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRotation = GetComponent<PlayerRotation>();
    }

    private void Update()
    {
        _playerMovement.Move();
        _playerRotation.Rotate();
    }

    private void OnEnable()
    {
        _inputPlayer.Enable();
    }

    private void OnDisable()
    {
        _inputPlayer.Disable();
    }
}
