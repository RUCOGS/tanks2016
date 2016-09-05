using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Mainbullet : NetworkBehaviour {
    public GameObject explosion;
    int time = 0;
    float spd = 5F;
    Vector3 grav = Vector3.zero;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left*spd,Space.Self);
        transform.Translate(grav, Space.World);
        time++;
        spd *= 0.97F;
        if (time > 10)
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
        if(time==0 && other.gameObject.tag == "Player") { }
        else { Destroy(gameObject); }
    }
}