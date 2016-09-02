using UnityEngine;
using System.Collections;

public class Turret_P1 : MonoBehaviour {
    public GameObject inner;
    bool flipped = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up, Space.World);
            transform.Rotate(Vector3.up, Space.World);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.down, Space.World);
            transform.Rotate(Vector3.down, Space.World);
        }
        if (inner.transform.eulerAngles.z<270 && inner.transform.eulerAngles.z >210 && !flipped)
        {
            transform.Rotate(Vector3.up * 180, Space.World);
            inner.transform.Rotate(Vector3.down * 180, Space.World);
            flipped = true;
        }
        if (inner.transform.eulerAngles.z > 270 && flipped)
        {
            transform.Rotate(Vector3.up * 180, Space.World);
            inner.transform.Rotate(Vector3.down * 180, Space.World);
            flipped = false;
        }
    }
}