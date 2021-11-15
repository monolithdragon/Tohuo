using UnityEngine;
			
public class Weapon : MonoBehaviour
{
	[SerializeField] private float fireRate;
	[SerializeField] private float damage;
    [SerializeField] private GameObject projectilePrefab;

	private float _cooldown = -1;
    private bool _canFire;		

    private void Update()
	{
		if (_cooldown > 0)
		{			
			_canFire = false;
			_cooldown -= Time.deltaTime;
		}
		else
		{
			_canFire = true;
		}
	}

	public void StartFire()
	{
		if (_canFire)
        {
            _cooldown = fireRate;
			CreateProjectile();
        }
    }        

    public void StopFire()
	{
		if (_canFire)
		{
			_cooldown = -1;
		}
	}

	private void CreateProjectile()
	{		
		var go = Instantiate(projectilePrefab, transform.position, transform.rotation);
		
		if (go && go.TryGetComponent(out Projectile projectile))
        {
			go.layer = transform.parent.parent.tag == "Player" ? LayerMask.NameToLayer("PlayerProjectile") : LayerMask.NameToLayer("EnemyProjectile");
			projectile.Damage = damage;
        }
	}
}	

