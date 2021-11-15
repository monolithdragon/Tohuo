using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	/// <summary>
	/// Get World Position.
	/// </summary>
	/// <param name="screenPosition">Position like Input.mousePosition</param>	
	/// <returns></returns>
	public static Vector3 GetWorldPosition(Vector3 screenPosition)
	{
		var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		return worldPosition;
	}

	/// <summary>
	/// Get direction.
	/// </summary>
	/// <param name="fromPosition"></param>
	/// <param name="toPosition"></param>
	/// <returns>Normalized direction</returns>
	public static Vector3 GetDirection(Vector3 fromPosition, Vector3 toPosition)
	{
		return (fromPosition - toPosition).normalized;
	}

	/// <summary>
	/// Returns angle by direction
	/// </summary>
	/// <param name="dir"></param>
	/// <returns></returns>
	public static float GetAngleFromVector(Vector3 dir)
	{
		return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
	}
}
