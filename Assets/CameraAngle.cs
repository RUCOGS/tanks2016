using UnityEngine;
using System.Collections;

public class CameraAngle : MonoBehaviour {
    public GameObject Trace;
    new Vector3 dis;
    new float rot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        dis = Trace.transform.position - transform.position;
        transform.Translate(dis*0.02F,Space.World);
        rot = Quaternion.Angle(Trace.transform.rotation, transform.rotation)*.05F;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Trace.transform.rotation, rot);
    }
}
