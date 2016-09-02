using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Mainbullet : NetworkBehaviour {
    public GameObject explosion;
    int time = 0;
    
    Vector3 grav = Vector3.zero;
    public int thrust;

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if (transform.position.y < -3) { Destroy(gameObject); }
        if (time > 600) { Destroy(gameObject); }
    }

    void OnCollisionEnter(Collision other)
    {
        if (time > 2)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(other.gameObject);
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}