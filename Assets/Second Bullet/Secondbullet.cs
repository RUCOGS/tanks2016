using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Secondbullet : NetworkBehaviour {
    public GameObject explosion;
    int time = 0;
    float spd = 7.0F;
    Vector3 grav = Vector3.zero;
    [Command]
    public void CmdSummonExplosion2(Vector3 loc)
    {
        var expl = (GameObject)Instantiate(explosion, loc, Quaternion.identity);
        NetworkServer.Spawn(expl);
    }
    [ClientRpc]
    public void RpcSummonExplosion2(Vector3 loc)
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
        spd *= 0.95F;
        if (time > 75)
        {
            grav += Vector3.down * .01F;
        }
        if (transform.position.y < -2) {
            CmdSummonExplosion2(new Vector3(transform.position.x,-1.8F,transform.position.z));
            RpcSummonExplosion2(new Vector3(transform.position.x,-1.8F, transform.position.z));
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (time != 0)
        {
            CmdSummonExplosion2(new Vector3(transform.position.x, -1.8F, transform.position.z));
            RpcSummonExplosion2(new Vector3(transform.position.x, -1.8F, transform.position.z));
        }
        if (time == 0 && other.gameObject.tag == "Player") { }
        else { Destroy(gameObject); }
    }
}
