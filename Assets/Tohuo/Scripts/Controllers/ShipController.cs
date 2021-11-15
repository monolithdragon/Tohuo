using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ShipController : MonoBehaviour
{
    protected Vector3 direction;
    protected float angle;

    private List<Weapon> weapons;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>().ToList();
    }

    protected void Fire(bool canFire)
    {
        if (weapons.Count <= 0) return;

        if (canFire)
        {
            weapons.ForEach(weapon => weapon.StartFire());
        }
        else
        {
            weapons.ForEach(weapon => weapon.StopFire());
        }
    }
}
