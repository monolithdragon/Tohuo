using UnityEngine;

public class ShipEngine : MonoBehaviour
{
	[SerializeField] private float maxSpeed = 100f;

	private Rigidbody2D _rigidbody;
	private Vector3 _direction;
	private float _rotationAngle;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
	{
		_rigidbody.MovePosition(transform.position + (_direction * maxSpeed * Time.fixedDeltaTime));
		_rigidbody.rotation = _rotationAngle;			
	}

	public void HandleMovement(Vector3 newDirection, float angle)
	{
		_direction = newDirection;
		_rotationAngle = angle;
	}

}
	

