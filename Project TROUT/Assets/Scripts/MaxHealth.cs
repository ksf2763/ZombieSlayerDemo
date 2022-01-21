using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentHP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        currentHP = GameObject.Find("Player").GetComponent<PlayerHealth>().currentHP;
        if (other.gameObject.tag == "Player" && currentHP < 5)
        {
            currentHP = 5;
            GameObject.Find("Player").GetComponent<PlayerHealth>().currentHP = currentHP;

            Destroy(this.gameObject);
            Debug.Log("Enter: Max Health");
        }
    }
}
