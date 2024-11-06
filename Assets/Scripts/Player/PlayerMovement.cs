using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private Transform _transform;
    private InputPlayer _inputPlayer;
    private CharacterController _characterController;

    [Inject]
    private void Construct(PlayerController playerController, InputPlayer inputPlayer)
    {
        _transform = transform;  
        _inputPlayer = inputPlayer;
        _speed = playerController.config.speedWalk;
        _characterController = GetComponent<CharacterController>();
    }

    public void Move()
    {
        Vector2 directionInput = _inputPlayer.Player.Move.ReadValue<Vector2>(); 
        Vector3 directionMovement = _transform.right * directionInput.x + Vector3.up * Physics.gravity.y + _transform.forward * directionInput.y;

        _characterController.Move(directionMovement * Time.deltaTime * _speed);
    }
}
