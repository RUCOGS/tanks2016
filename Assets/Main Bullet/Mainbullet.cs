using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Mainbullet : NetworkBehaviour {
    public GameObject explosion;
    int time = 0;
    float spd = 5F;
    Vector3 grav = Vector3.zero;
    [ClientRpc]
    public void RpcSummonExplosion1(Vector3 loc)
    {
        var expl = (GameObject)Instantiate(explosion, loc, Quaternion.identity);
        NetworkServer.Spawn(expl);
    }
    [Command]
    public void CmdSummonExplosion1(Vector3 loc)
    {
        var expl = (GameObject)Instantiate(explosion, loc, Quaternion.identity);
        NetworkServer.Spawn(expl);
        Destroy(gameObject);
    }
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
            RpcSummonExplosion1(new Vector3(transform.position.x,-1.8F,transform.position.z));
            CmdSummonExplosion1(new Vector3(transform.position.x, -1.8F, transform.position.z));
            //Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (time != 0)
        {
            RpcSummonExplosion1(new Vector3(transform.position.x, -1.8F, transform.position.z));
            CmdSummonExplosion1(new Vector3(transform.position.x, -1.8F, transform.position.z));
        }
        if(time==0 && other.gameObject.tag == "Player") { }
        else { Destroy(gameObject); }
    }
}