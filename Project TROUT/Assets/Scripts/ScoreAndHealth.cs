using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHealth : MonoBehaviour
{
	public Text score;
	public int points = 0;

    public int Points
    {
        get => points;
        set => points = value;
    }
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {	
		score.text = "Score: " + points;
    }
}
