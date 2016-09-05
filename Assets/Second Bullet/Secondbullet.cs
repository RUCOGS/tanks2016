using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Secondbullet : NetworkBehaviour {
    public GameObject explosion;
    int time = 0;
    float spd = 7.0F;
    Vector3 grav = Vector3.zero;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left*spd,Space.Self);
        transform.Translate(grav, Space.World);
        time++;
        spd *= 0.95F;
        if (time > 75)
        {
            grav += Vector3.down * .01F;
        }
        if (transform.position.y < -2) {
            Instantiate(explosion, transform.position + Vector3.up*.05F, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (time != 0)
        {
            Instantiate(explosion, transform.position + Vector3.up * .05F, Quaternion.identity);
        }
        if (time == 0 && other.gameObject.tag == "Player") { }
        else { Destroy(gameObject); }
    }
}
