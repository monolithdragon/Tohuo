using UnityEngine;

namespace Tohuo
{
	[CreateAssetMenu(fileName = "Weapon", menuName = "Tohuo/Create Weapon")]
	public class Weapon : ScriptableObject
	{		
		public float fireRate;
		public GameObject projectile;		
	}
	
}
