using UnityEngine;

public class AIShipController : ShipController
{
	private Transform _target;
	private bool _hasFire;

	private void Start()
	{
		_target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		if (_target != null)
		{
			direction = Utils.GetDirection(_target.position, transform.position);
			angle = Utils.GetAngleFromVector(direction);
			
			if (TryGetComponent(out ShipEngine shipEngine))
			{
				shipEngine.HandleMovement(direction, angle);
			}

			if (Vector3.Distance(_target.position, transform.position) < 8f)
            {
				Fire(true);
				_hasFire = true;
            }
			else
            {
                if (_hasFire)
                {
					Fire(false);
				}				
            }
            
		}
		
	}
}
