using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] pausedObjects;
    [SerializeField] GameObject[] subMenus;

    void Start()
    {
        Time.timeScale = 1.0f;
        pausedObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (Time.timeScale == 1.0f)
            {
                showPaused();
            }
            else if (Time.timeScale == 0) {
                hidePaused();
            }
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in subMenus)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(false);
        }
        Time.timeScale = 1.0f;
        if(GetComponent<AudioSettings>())
            GetComponent<AudioSettings>().Pause = false;
    }

    public void showPaused()
    {
        foreach (GameObject g in pausedObjects)
        {
            g.SetActive(true);
        }
        Time.timeScale = 0;
        if (GetComponent<AudioSettings>())
            GetComponent<AudioSettings>().Pause = true;
    }
}
