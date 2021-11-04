using UnityEngine;

namespace Tohuo
{
	[RequireComponent(typeof(BoxCollider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class ShipController : MonoBehaviour
	{
		[SerializeField] private float moveSpeed = 300f;

		private Rigidbody2D _rigidbody;
		private Vector2 _position;
		private float _rotateAngle;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnEnable()
		{
			GameEvents.Instance.OnFireEvent += HandleFire;
			GameEvents.Instance.OnStopFireEvent += HandleStopFire;
		}

		private void OnDestroy()
		{
			GameEvents.Instance.OnFireEvent -= HandleFire;
			GameEvents.Instance.OnStopFireEvent -= HandleStopFire;
		}

		private void FixedUpdate()
        {
			_rigidbody.velocity = _position * (moveSpeed * Time.fixedDeltaTime);
			_rigidbody.rotation = _rotateAngle;
        }

        public void HandleMovement(Vector2 dir)
        {
			_position = dir;
			_rotateAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; ;
        }

		public void HandleFire()
		{
			Debug.Log("Fire");
		}

		private void HandleStopFire()
		{
			Debug.Log("StopFire");
		}

	}
	
}
