using UnityEngine;
using Zenject;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private Transform _trHand;

    private bool _isGrab;
    private float _distanceInteract;

    private Item _item;
    private Transform _trCamera;
    private InputPlayer _inputPlayer;

    [Inject]
    private void Construct(PlayerController playerController, InputPlayer inputPlayer)
    {
        _inputPlayer = inputPlayer;
        _trCamera = Camera.main.transform;
        _distanceInteract = playerController.config.distanceInteract;
        _inputPlayer.Player.Interact.performed += contex => Interact();
    }

    public void Interact()
    {

        if (Physics.Raycast(_trCamera.position, _trCamera.forward, out RaycastHit hitInfo, _distanceInteract))
        {
            if (hitInfo.transform.TryGetComponent(out Item item))
            {
                if (!_isGrab)
                {
                    _item = item;
                    GrabItem(_item);
                }

                _isGrab = true;                  
            }

            if (hitInfo.transform.TryGetComponent(out Car car))
            {
                if (_isGrab)
                    car.PutItem(_item);

                _isGrab = false;
            }
        }
    }

    private void GrabItem(Item item)
    {
        item.SetLayerMask(Constants.LAYER_MASK_HAND);

        item.transform.parent = _trHand;
        item.transform.localPosition = _trHand.localPosition;
        item.transform.localRotation = _trHand.localRotation;
    }
}
