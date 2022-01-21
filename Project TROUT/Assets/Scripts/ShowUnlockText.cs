using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUnlockText : MonoBehaviour
{
    private Text unlockText;

    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        unlockText = GameObject.FindGameObjectWithTag("UnlockText").GetComponent<Text>(); ;
        unlockText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetComponent<UnlockDoor>().playerNearDoor)
            {
                unlockText.enabled = true;
                Debug.Log("Near: " + doors[i]);
            }
            else
            {
                unlockText.enabled = false;           
            }
        }

    }
}
