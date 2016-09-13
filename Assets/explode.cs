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
        if (time > 5) { Destroy(gameObject); }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            /*if (other.transform.GetChild(6).gameObject.activeSelf)
            {
                other.transform.GetChild(7).gameObject.SetActive(true);
                other.transform.GetChild(7).transform.position = other.transform.position+Vector3.down*2F;
                other.transform.GetChild(7).parent = null;
                other.transform.GetChild(6).gameObject.SetActive(false);
            }
            other.gameObject.SetActive(false);*/
            //Destroy(other.gameObject);
            other.transform.parent.gameObject.GetComponent<PlayerScript>().RpcDeath();
        }
    }
}
