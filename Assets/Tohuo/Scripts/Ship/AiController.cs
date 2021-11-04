using UnityEngine;

namespace Tohuo
{
	[RequireComponent(typeof(ShipController))]
	public class AiController : MonoBehaviour
	{
		private ShipController _controller;
		private Transform _target;

		private void Awake()
		{
			_controller = GetComponent<ShipController>();
		}
		
		private void Start()
		{
			_target = GameObject.FindGameObjectWithTag("Target").transform;
		}
		
		private void Update()
		{
			var dir = (_target.position - transform.position).normalized;
			_controller.HandleMovement(dir);

			if (Vector2.Distance(_target.position, transform.position) <= 6f)
			{
				GameEvents.Instance.Fire();
			}
			else
			{
				GameEvents.Instance.StopFire();
			}
		}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Target"))
            {
				Destroy(gameObject);
            }
        }
    }	
}
