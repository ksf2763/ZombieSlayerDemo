using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Text health;
    public float currentHP = 5;
    private float maxHP = 5;
    private float damage = 1;
    private float timeTillNextAttack = 1.0f;
    private float nextAttack = 1.0f;
    public bool hpRegain = false;
    public float timeToStartRegain = 8.0f;
    private float startTimer = 0.0f;
    public float timeBetweenRegain = 1.0f;
    private float betweenTimer = 0.0f;
    void Start()
    {
        health = GameObject.Find("Health").GetComponent<Text>();
    }

    void Update()
    {
       
        if (currentHP <= 0) 
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        if (hpRegain && maxHP != currentHP)
        {
            // I replaced the Coroutine with this timer to allow me to have a time between each hp regan so it was instant, the Coroutine wasn't working
            // for me
            startTimer += Time.deltaTime;
            if (startTimer >= timeToStartRegain)
            {
                betweenTimer += Time.deltaTime;
                if (betweenTimer >= timeBetweenRegain) 
                {
                    currentHP++;
                    betweenTimer %= timeBetweenRegain;
                }
            }
        }


        if (currentHP == maxHP) {
            hpRegain = false;
            startTimer = 0;
            betweenTimer = 0;
        }

        health.text = "Health: " + currentHP;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nextAttack += Time.deltaTime; 
            if (nextAttack >= timeTillNextAttack)
            {
                hpRegain = false;
                startTimer = 0;
                betweenTimer = 0;
                nextAttack = 0;
                currentHP -= damage;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Hurt");
                //Debug.Log(currentHP);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Enemy" && currentHP != maxHP)
        {
            hpRegain = true;
            nextAttack = 1; 
        }
    }

}
