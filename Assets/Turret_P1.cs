﻿using UnityEngine;
using System.Collections;

public class Turret_P1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up, Space.World);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.down, Space.World);
        }
    }
}