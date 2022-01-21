using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	
	private Rigidbody playerBody;
	private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponentInChildren<Rigidbody>();
		camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = Vector3.zero;
		if(Input.GetKey("w"))
		{
			//transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
			direction.z += 1;
		}
		else if(Input.GetKey("s"))
		{
			//transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
			direction.z -= 1;
		}
		
		if(Input.GetKey("a"))
		{
			//transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * speed;
			direction.x -= 1;
		}
		else if(Input.GetKey("d"))
		{
			//transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * speed;
			direction.x += 1;
		}

		if (direction != Vector3.zero) ;
			playerBody.velocity = direction.normalized * speed;

		camera.transform.position = playerBody.transform.position + new Vector3(0, 20, 0);

		/*
		if (transform.position.x >= 48.0f)
		{
			transform.position = new Vector3(48.0f, transform.position.y, transform.position.z);
		}
		
		if(transform.position.z >= 48.0f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 48.0f);
		}
		
		if(transform.position.x <= -48.0f)
		{
			transform.position = new Vector3(-48.0f, transform.position.y, transform.position.z);
		}
		
		if(transform.position.z <= -48.0f)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -48.0f);
		}
		Debug.Log(GetComponentInChildren<Rigidbody>().velocity);
		*/
    }
}
