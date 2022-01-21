using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Used as a deveolper tool to see where the raytracing will go if the player shot
        Vector3 lineOrigin = transform.position;
        Debug.DrawRay(lineOrigin, transform.forward * weaponRange, Color.red);
    }
}
