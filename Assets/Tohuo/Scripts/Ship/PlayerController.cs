using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tohuo
{
	[RequireComponent(typeof(ShipController))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private Joystick joystick;

		private ShipController _controller;

		private void Awake()
		{
			_controller = GetComponent<ShipController>();
		}

		private void Update()
		{
			_controller.HandleMovement(joystick.Direction);
		}

	}
}
