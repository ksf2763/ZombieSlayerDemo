using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStore : MonoBehaviour
{

	//how many points player needs to unlock this door
	public int pointsCost = 500;

	//Refernce to player for checking score / removing points
	private GameObject player;

	[SerializeField] float weaponType;


	//is the player touching a door?
	public bool playerNearDoor = false;

	// Text component to show the player how to open the door
	private Text unlockText;

	private string purchased = "event:/Purchase";
	private string failed = "event:/Doors/Door Closed";

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		unlockText = GameObject.FindGameObjectWithTag("UnlockText").GetComponent<Text>();
		unlockText.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space") && playerNearDoor == true)
		{
			//Check if player has enough points, subtract and continue if they do
			if (player.GetComponent<ScoreAndHealth>().points < pointsCost)
			{
				FMODUnity.RuntimeManager.PlayOneShot(failed);
				return;
			}

			player.GetComponent<ScoreAndHealth>().points -= pointsCost;
			if(player.GetComponent<Shoot>().currentGun.name == this.GiveNewGun().name)
            {
				player.GetComponent<Shoot>().currentGun.ammoLeft += this.GiveNewGun().ammoLeft;
            }
            else
            {
				player.GetComponent<Shoot>().currentGun = this.GiveNewGun();
			}

			FMODUnity.RuntimeManager.PlayOneShot(purchased);
			//unlockText.enabled = false;
		}
	}

	Gun GiveNewGun()
    {
        switch (weaponType)
        {
			case 0:
				return new AssaultRifle();
			case 1:
				return new SniperRifle();
			case 2:
				return new Minigun();
			default:
				return new AssaultRifle();
        }
    }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNearDoor = true;
			unlockText.text = "Press 'Space' to buy " + GiveNewGun().name + " with " + GiveNewGun().ammoLeft + " rounds " + " for " + pointsCost + " points";
			unlockText.enabled = true;
			//Debug.Log("touching");
		}
		else
		{
			playerNearDoor = false;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerNearDoor = false;
			unlockText.enabled = false;
		}
	}
}
