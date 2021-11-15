using UnityEngine;

public class PlayerShipController : ShipController
{
	private Vector2 _newPosition;

    private void Start()
    {
		HandleMovement.Instance.OnMovement += SetNewPosition;
		HandleAttack.Instance.OnAttack += Fire;
    }    

    private void OnDestroy()
    {
		HandleMovement.Instance.OnMovement -= SetNewPosition;
		HandleAttack.Instance.OnAttack -= Fire;
	}    

    private void Update()
    {
		direction = Utils.GetDirection(transform.position, _newPosition);
		angle = Utils.GetAngleFromVector(direction);

		if (TryGetComponent(out ShipEngine shipEngine))
		{
			shipEngine.HandleMovement(direction, angle);
		}
	}	

	private void SetNewPosition(Vector2 direction)
	{
		_newPosition = (Vector2)transform.position - direction;
	}
}
	

