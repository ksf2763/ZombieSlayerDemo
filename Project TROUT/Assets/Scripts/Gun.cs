using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public string name = "gun";
    public float fireRate = .25f;
    public float weaponRange = 50f;
    [SerializeField] public float damage = 1f;
    public bool hasAmmo = false;
    public float ammoLeft = 0;
    public bool fullAuto = false;

    // Start is called before the first frame update
    public Gun()
    {
        
    }
}
public class Pistol : Gun
{
    public Pistol()
    {
        name = "Pistol";
        fireRate = .25f;
        weaponRange = 50f;
        damage = 1f;
    }
}

public class AssaultRifle : Gun
{
    public AssaultRifle()
    {
        name = "AssaultRifle";
        fireRate = .1f;
        weaponRange = 30f;
        damage = .5f;
        fullAuto = true;
        hasAmmo = true;
        ammoLeft = 48;
    }
}


public class SniperRifle : Gun
{
    public SniperRifle()
    {
        name = "SniperRifle";
        fireRate = 1f;
        weaponRange = 100f;
        damage = 2.5f;
        hasAmmo = true;
        ammoLeft = 36;
    }
}

public class Minigun : Gun
{
    public Minigun()
    {
        name = "Minigun";
        fireRate = .05f;
        weaponRange = 30f;
        damage = .25f;
        hasAmmo = true;
        ammoLeft = 120;
        fullAuto = true;
    }
}