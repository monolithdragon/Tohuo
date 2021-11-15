using UnityEngine;

public abstract class Ship : MonoBehaviour
{
	[SerializeField] private Sprite shipSprite;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject deathEffect;

    private float _currenthealth;

    private void Awake()
    {
        if (TryGetComponent(out SpriteRenderer renderer))
        {
            renderer.sprite = shipSprite;
        }

        _currenthealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            var damage = collision.gameObject.GetComponent<Projectile>().Damage;
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        _currenthealth -= damage;

        if (_currenthealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (deathEffect)
        {
            var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        Destroy(gameObject);
    }    
}
	

