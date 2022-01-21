using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGen : MonoBehaviour
{
    // Start is called before the first frame update
    private float percentage = 5;
    public List<GameObject> powerUpList;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePowerUp(Transform transform)  
    {
        int random = Random.Range(0,101);

        if (random <= percentage) {
            // Chose Powerup
            // Spawn that PowerUp
            int randomIndex = Random.Range(0, 4);
            GameObject chosenPowerUp = powerUpList[randomIndex];
            Instantiate(chosenPowerUp, transform.position, Quaternion.identity);

        }
    } 
}
