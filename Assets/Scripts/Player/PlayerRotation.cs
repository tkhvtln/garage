using UnityEngine;
using Zenject;

public class PlayerRotation : MonoBehaviour
{
    private float _speed;
    private float _yRotation;

    private InputPlayer _inputPlayer;
    private Transform _transform;
    private Transform _trCamera;

    [Inject]
    private void Construct(PlayerController playerController, InputPlayer inputPlayer)
    {
        _transform = transform;
        _inputPlayer = inputPlayer;
        _trCamera = Camera.main.transform;
        _speed = playerController.config.speedRotate;
    }

    public void Rotate()
    {
        Vector2 directionInput = _inputPlayer.Player.Rotate.ReadValue<Vector2>() * _speed * Time.deltaTime;

        _yRotation -= directionInput.y;
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        _trCamera.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        _transform.Rotate(Vector3.up * directionInput.x);
    }
}
