using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerScript : NetworkBehaviour {
    int deathcd = 0;
    Vector3 startloc;
    //Body
    public GameObject bullet2;
    int reloadtime2 = 0;
    GameObject tempb = null;
    //MainCamera
    public GameObject Trace;
    Vector3 dis;
    float rot;
    //TurretP1
    public GameObject inner;
    bool flipped = false;
    //TurretP2
    public GameObject bullet1;
    int reloadtime1 = 0;
    // Use this for initialization
    public Camera cam;
    public static int players;
    public Material blue;
    public Material green;
    public Material yellow;
    int playernum;
    public bool dead=false;

    [ClientRpc]
    public void RpcDeath()
    {
        if (transform.GetChild(0).transform.GetChild(6).gameObject.activeSelf)
        {
            transform.GetChild(0).transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(7).transform.position = transform.GetChild(0).transform.position+Vector3.down*2F;
            transform.GetChild(0).transform.GetChild(7).transform.parent = null;
            transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    [ClientRpc]
    public void RpcRevive()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    [ClientRpc]
    public void RpcFlag(Material x)
    {
        Material[] mats = transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials;
        mats[0] = blue;
        transform.GetChild(0).transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials = mats;
    }

    [Command]
    void CmdFire1()
    {
        var bullet = (GameObject)Instantiate(bullet1, transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.position, transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.rotation);
        NetworkServer.Spawn(bullet);
    }

    [Command]
    void CmdFire2()
    {
        tempb = (GameObject)Instantiate(bullet2, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        tempb.transform.Translate(new Vector3(-3, -.75F, -.75F));
        NetworkServer.Spawn(tempb);
        tempb = (GameObject)Instantiate(bullet2, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        tempb.transform.Translate(new Vector3(-3, -.75F, .75F));
        NetworkServer.Spawn(tempb);
    }

    void Start () {
        players += 1;
        playernum = players;
        transform.GetChild(0).transform.GetChild(6).gameObject.SetActive(false);
        if (playernum == 2)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = blue;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = blue;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = blue;
            mats = transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = blue;
            transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            mats = transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = blue;
            transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
        }
        if (playernum == 3)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = green;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = green;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = green;
            mats = transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = green;
            transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            mats = transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = green;
            transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
        }
        if (playernum == 4)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = yellow;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = yellow;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = yellow;
            mats = transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = yellow;
            transform.GetChild(2).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            mats = transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[0] = yellow;
            transform.GetChild(2).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
        }
        startloc = transform.GetChild(0).position;
        if (isLocalPlayer) { return; }
        cam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) { return; }
        //Main Camera
        dis = Trace.transform.position - transform.GetChild(1).transform.position;
        transform.GetChild(1).transform.Translate(dis * 0.05F, Space.World);
        rot = Quaternion.Angle(Trace.transform.rotation, transform.GetChild(1).transform.rotation) * .1F;
        transform.GetChild(1).transform.rotation = Quaternion.RotateTowards(transform.GetChild(1).transform.rotation, Trace.transform.rotation, rot);
        //Body
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (reloadtime2 > 0) { reloadtime2--; }
            if (Input.GetKey("d"))
            {
                transform.GetChild(0).transform.Rotate(Vector3.up, Space.World);
            }
            if (Input.GetKey("a"))
            {
                transform.GetChild(0).transform.Rotate(Vector3.down, Space.World);
            }
            if (Input.GetKey("w"))
            {
                transform.GetChild(0).transform.Translate(Vector3.left * 0.1F, Space.Self);
            }
            if (Input.GetKey("s"))
            {
                transform.GetChild(0).transform.Translate(Vector3.right * 0.1F, Space.Self);
            }
            if (Input.GetKeyDown("space") && reloadtime2 == 0)
            {
                CmdFire2();
                reloadtime2 = 250;
            }
            //Turret_P1
            if (Input.GetKey("right"))
            {
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.up, Space.World);
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.up, Space.World);
            }
            if (Input.GetKey("left"))
            {
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.down, Space.World);
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.down, Space.World);
            }
            if (inner.transform.eulerAngles.z < 270 && inner.transform.eulerAngles.z > 210 && !flipped)
            {
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.up * 180, Space.World);
                inner.transform.Rotate(Vector3.down * 180, Space.World);
                flipped = true;
            }
            if (inner.transform.eulerAngles.z > 270 && flipped)
            {
                transform.GetChild(0).transform.GetChild(3).transform.Rotate(Vector3.up * 180, Space.World);
                inner.transform.Rotate(Vector3.down * 180, Space.World);
                flipped = false;
            }
            //Turret_P2
            if (reloadtime1 > 0) { reloadtime1--; }
            if (Input.GetKey("up"))
            {
                if (Mathf.Cos(Mathf.PI * transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.eulerAngles.z / 180) < Mathf.Cos(Mathf.PI * (transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.eulerAngles.z + 5) / 180))
                    transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.Rotate(Vector3.forward, Space.Self);
            }
            if (Input.GetKey("down"))
            {
                if (Mathf.Cos(Mathf.PI * transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.eulerAngles.z / 180) > Mathf.Cos(Mathf.PI * (transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.eulerAngles.z - 5) / 180))
                {
                    transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.Rotate(Vector3.back, Space.Self);
                }
            }
            if (Input.GetKeyDown("return") && reloadtime1 == 0)
            {
                CmdFire1();
                reloadtime1 = 150;
            }
        }
        else
        {
            deathcd += 1;
            if (deathcd >= 900 && !dead)
            {
                deathcd = 0;
                RpcRevive();
                transform.GetChild(0).position = startloc;
            }
        }
    }
}
