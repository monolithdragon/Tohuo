using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private GameObject deadEffect;

    private Rigidbody2D _rigidbody;

    public float Damage { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        Destroy(gameObject, lifeTime);          
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion(collision.transform);
    }

    private void Explosion(Transform transform)
    {
        if (deadEffect)
        {                
            var effect = Instantiate(deadEffect, transform.position, transform.rotation);
            Destroy(effect, 0.1f);
        }

        Destroy(gameObject);
    }
}
    

