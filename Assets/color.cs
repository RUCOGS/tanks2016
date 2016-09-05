using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class color : NetworkBehaviour {
    public static int players;
    public Material blue;
    public Material green;
    public Material yellow;
	// Use this for initialization
	void Start () {
        players += 1;
        if (players == 2)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = blue;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = blue;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = blue;
        }
        if (players == 3)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = green;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = green;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = green;
        }
        if (players == 4)
        {
            Material[] mats = transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials;
            mats[3] = yellow;
            transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials = mats;
            transform.GetChild(0).transform.GetChild(3).transform.GetChild(1).GetComponent<Renderer>().material = yellow;
            transform.GetChild(0).transform.GetChild(5).GetComponent<Renderer>().material = yellow;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
