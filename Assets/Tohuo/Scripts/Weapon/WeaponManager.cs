using System.Collections.Generic;
using UnityEngine;

namespace Tohuo
{
	public class WeaponManager : Singleton<WeaponManager>
	{
		[SerializeField] private List<Transform> firePoints;
		[SerializeField] private List<Weapon> _weapons;

		private void Awake()
		{
		}
		
		private void Update()
		{
		}
		
	}
	
}
