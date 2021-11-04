using UnityEngine;
using UnityEngine.UIElements;

namespace Tohuo
{
	public class Projectile : MonoBehaviour
	{
		public float damage;
		public float range;
		[SerializeField] private float speed = 0.1f;
		[SerializeField] private ParticleSystem deadEffect;

		private Rigidbody2D _rigidbody;
        private Vector3 _distance;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _distance = new Vector3(transform.position.x + range, transform.position.y + range, 0).normalized;
        }

        private void Update()
        {
            Debug.Log(Vector2.Distance(_distance, transform.position));
            if (Vector2.Distance(_distance, transform.position) > range)
            {
                Explosion(transform);
            }
        }

        private void FixedUpdate()
{
            _rigidbody.velocity = _distance * (speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Explosion(collision.transform);
        }

        private void Explosion(Transform transform)
        {
            ParticleSystem effect = null;

            if (deadEffect)
            {                
                effect = Instantiate(deadEffect, transform);
            }

            Destroy(gameObject);
            Destroy(effect, 1f);
        }
    }
}
