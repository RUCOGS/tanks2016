using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class explode : NetworkBehaviour {
    int time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        //transform.Translate(Vector3.down,Space.World);
        if (time > 60) { Destroy(gameObject); }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
