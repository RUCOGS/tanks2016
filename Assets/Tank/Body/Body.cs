using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {
    public GameObject bullet2;
    int reloadtime2 = 0;
    GameObject tempb = null;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (reloadtime2 > 0) { reloadtime2--; }
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
        if (Input.GetKeyDown("space") && reloadtime2 == 0)
        {
            tempb= (GameObject)Instantiate(bullet2, transform.position, transform.rotation);
            tempb.transform.Translate(new Vector3(-3, -.75F, -.75F));
            tempb = (GameObject)Instantiate(bullet2, transform.position, transform.rotation);
            tempb.transform.Translate(new Vector3(-3, -.75F, .75F));
            reloadtime2 = 250;
        }
    }
}
