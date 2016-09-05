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
    void Start () {
        startloc = transform.GetChild(0).position;
        if (isLocalPlayer) { return; }
        cam.enabled = false;
	}
    //Collision detection
    
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
                tempb = (GameObject)Instantiate(bullet2, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
                tempb.transform.Translate(new Vector3(-3, -.75F, -.75F));
                tempb = (GameObject)Instantiate(bullet2, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
                tempb.transform.Translate(new Vector3(-3, -.75F, .75F));
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
                Instantiate(bullet1, transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.position, transform.GetChild(0).transform.GetChild(3).transform.GetChild(4).transform.rotation);
                reloadtime1 = 150;
            }
        }
        else
        {
            deathcd += 1;
            if (deathcd >= 900)
            {
                deathcd = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).position = startloc;
            }
        }
    }
}
