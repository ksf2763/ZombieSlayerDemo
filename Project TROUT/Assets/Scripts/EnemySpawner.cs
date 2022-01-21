using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
	public List<GameObject> enemyType = new List<GameObject>(); 
	public int maxNumOfEnemies = 0;
	public float maxSpeed = 5.0f;
	public List<GameObject> enemyList;
	public List<GameObject> spawnLocations = new List<GameObject>();
	private float xPos;
	private float zPos;
	private List<MortalEntity> mortalEntityRef = new List<MortalEntity>();
	private List<NavMeshAgent> enemyAgent = new List<NavMeshAgent>();

	int maxZombiesInWave = 20;
	FMOD.Studio.EventInstance ambience;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < enemyType.Count; i++)
		{
			mortalEntityRef[i] = enemyType[i].GetComponent<MortalEntity>();
			enemyAgent[i] = enemyType[i].GetComponent<NavMeshAgent>();
		}
		enemyList = new List<GameObject>();
		ambience = GetComponent<FMODUnity.StudioEventEmitter>().EventInstance;
    }
	
	void Update()
	{
		if(enemyList.Count == 0)
		{
			maxNumOfEnemies += 1;
			EnemyDrop();
			if (maxNumOfEnemies > maxZombiesInWave)
				maxZombiesInWave = maxNumOfEnemies;
		}
		ambience.setProperty(0, maxZombiesInWave / enemyList.Count);
	}
	
	void EnemyDrop()
	{	
		//difficulty so far is mostly increasing zombie speed after every wave
		foreach (NavMeshAgent agent in enemyAgent)
		{
			if(agent.speed <= maxSpeed)
			{
				agent.speed += .2f ;
			}
		}
		
		/*
		if(maxNumOfEnemies > 1)
		{
			//doesn't work due to hp being clamped in MortalEntity
			//mortalEntityRef.Health = 6;
		}
		
		else if(maxNumOfEnemies > 19)
		{
			mortalEntityRef.damage = 2;
		}
		*/
		for (int i = 0; i < maxNumOfEnemies; i++)
		{
			//if there unique spawn locations remaining, use them
			if(i < spawnLocations.Count)
			{
				xPos = spawnLocations[i].transform.position.x;
				zPos = spawnLocations[i].transform.position.z;
			}
			//otherwise, have extra zombies share spawns at random
			else
			{
				int randomSpawn = Random.Range(0, spawnLocations.Count);
				xPos = spawnLocations[randomSpawn].transform.position.x;
				zPos = spawnLocations[randomSpawn].transform.position.z;
			}
			
			//add new enemies to the fray after a certain amount of waves have passed
			GameObject randomEnemy;
			if(maxNumOfEnemies >= 5 && maxNumOfEnemies <= 9)
			{
				randomEnemy = enemyType[Random.Range(0, 2)];
			}
			else if (maxNumOfEnemies >= 10)
			{
				randomEnemy = enemyType[Random.Range(0, enemyType.Count)];
			}
			else
			{
				randomEnemy = enemyType[0];
			}		
			enemyList.Add(Instantiate(randomEnemy, new Vector3(xPos, 1.5f, zPos), Quaternion.identity));
		}
	}
}
