using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class flags : NetworkBehaviour {
    Vector3 startloc;
    Material[] mats;
    public GameObject tankn;
    public Transform playern;
	// Use this for initialization
	void Start () {
        startloc = transform.position;
        tankn = transform.parent.transform.GetChild(0).gameObject;
        playern = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.zero);
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.transform.parent == transform.parent)
            {
                if (transform.position != startloc)
                {
                    transform.position = startloc;
                }
                else
                {
                    if (other.transform.GetChild(6).gameObject.activeSelf)
                    {
                        other.transform.GetChild(6).gameObject.SetActive(false);
                        other.transform.GetChild(7).transform.GetComponent<flags>().tankn.SetActive(false);
                        other.transform.GetChild(7).transform.GetComponent<flags>().playern.GetComponent<PlayerScript>().dead = true;
                        other.transform.GetChild(7).parent = null;
                    }
                }
            }
            else
            {
                if (transform.parent == null)
                {
                    if (Vector3.Distance(other.transform.parent.position,startloc)<10)
                    {
                        transform.parent = other.transform.parent;
                        transform.position = startloc;
                    }
                    else
                    {
                        if (!other.transform.GetChild(6).gameObject.activeSelf)
                        {
                            other.transform.GetChild(6).gameObject.SetActive(true);
                            mats = other.transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials;
                            mats[0] = transform.GetChild(1).transform.GetComponent<Renderer>().materials[0];
                            other.transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials = mats;
                            transform.parent = other.transform;
                            //other.transform.parent.GetComponent<PlayerScript>().RpcFlag(transform.GetChild(1).transform.GetComponent<Renderer>().materials[0]);
                            gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    if (!other.transform.GetChild(6).gameObject.activeSelf)
                    {
                        other.transform.GetChild(6).gameObject.SetActive(true);
                        mats = other.transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials;
                        mats[0] = transform.GetChild(1).transform.GetComponent<Renderer>().materials[0];
                        other.transform.GetChild(6).transform.GetChild(1).transform.GetComponent<Renderer>().materials = mats;
                        transform.parent = other.transform;
                        //other.transform.parent.GetComponent<PlayerScript>().RpcFlag(transform.GetChild(1).transform.GetComponent<Renderer>().materials[0]);
                        gameObject.SetActive(false);
                    }
                }                
            }
        }
    }
}
