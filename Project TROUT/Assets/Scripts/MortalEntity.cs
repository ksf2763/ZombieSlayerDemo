using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameObject.Find("nameOfObjectYourScriptIsOn").GetComponent<move>().speed

public class MortalEntity : MonoBehaviour
{
    [SerializeField] public float currentHP = 5;
    [SerializeField] private float maxHP = 5;
    [SerializeField] private float damage = 1;
	private List<GameObject> spawnerList;
    private PowerUpGen powerUpGenScript;

    public float Health
    {
        get => currentHP;
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnerList = GameObject.Find("Game Manager").GetComponent<EnemySpawner>().enemyList;
        powerUpGenScript = GameObject.Find("Game Manager").GetComponent<PowerUpGen>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            powerUpGenScript.GeneratePowerUp(this.transform);
            spawnerList.Remove(this.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }

    void Damage(MortalEntity other)
    {
        other.Health -= this.damage;
    }
}
