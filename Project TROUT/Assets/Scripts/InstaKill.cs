using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> spawnerList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnerList = GameObject.Find("Game Manager").GetComponent<EnemySpawner>().enemyList;
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < spawnerList.Count; i++)
            {
                spawnerList[i].GetComponent<MortalEntity>().currentHP = 1;
            }
            Destroy(this.gameObject);
            Debug.Log("Enter: Insta Kill");
        }
    }
}
