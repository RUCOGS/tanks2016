using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.down, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.left*0.1F,Space.Self);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.right * 0.1F, Space.Self);
        }
    }
}
