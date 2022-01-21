using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    
    public Transform gunEnd;
    public Gun currentGun;
    public Text text;

    // How long the bullet trail is on the screen
    protected WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    // Bullet trail
    protected LineRenderer laserLine;
    protected float nextFire;

    private string bulletPing = "event:/Bullet Ricochet";
    private string bulletHit = "event:/Blood Splatter";
    private string bulletKill = "event:/Death Splatter";

    // Start is called before the first frame update
    void Start()
    {
        currentGun = new Pistol();
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Can the user shoot agin
        if ((Input.GetButtonDown("Fire1") || (Input.GetButton("Fire1") && currentGun.fullAuto)) && Time.time > nextFire && Time.timeScale == 1.0f) {
            nextFire = Time.time + currentGun.fireRate;

            StartCoroutine(ShotEffect());

            GetComponent<FMODUnity.StudioEventEmitter>().Play();

            // Begining of rayTrace
            Vector3 rayOrigin = gunEnd.transform.position;

            RaycastHit hit;

            // Begining of bullet trail
            laserLine.SetPosition(0, gunEnd.transform.position);

            

            // Checkes if the raytracing hit anything
            if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit, currentGun.weaponRange))
            {
                // Stops the trail on the object that it hit
                laserLine.SetPosition(1, hit.point);
                if (hit.transform.GetComponent<MortalEntity>())
                {
                    //Add 10 points for any hit on an enemy
                    hit.transform.GetComponent<MortalEntity>().Health -= currentGun.damage;
                    GetComponent<ScoreAndHealth>().Points += 10;

                    //Make it 100 points if that enemy dies
                    if (hit.transform.GetComponent<MortalEntity>().Health <= 0)
                    {
                        GetComponent<ScoreAndHealth>().Points += 90;
                        //Play zombie death sound
                        FMODUnity.RuntimeManager.PlayOneShot(bulletKill, hit.point);
                    }
                    else
                    {
                        //Play zombie hit sound
                        FMODUnity.RuntimeManager.PlayOneShot(bulletHit, hit.point);
                    }
                }
                else
                {
                    //Play bullet hit sound on hitlocation
                    FMODUnity.RuntimeManager.PlayOneShot(bulletPing, hit.point);
                }
            }
            else
            {
                // Continues until the raytrace hit the weapon range
                laserLine.SetPosition(1, rayOrigin + (transform.forward * currentGun.weaponRange));
            }

            if (currentGun.hasAmmo)
            {
                currentGun.ammoLeft--;
                if(currentGun.ammoLeft <= 0)
                {
                    currentGun = new Pistol();
                }
            }
        }

        text.text = currentGun.hasAmmo && currentGun.ammoLeft > 0 ? "Ammo: " + currentGun.ammoLeft : "";
    }

    // Shows the bullet trail
    private IEnumerator ShotEffect() 
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}