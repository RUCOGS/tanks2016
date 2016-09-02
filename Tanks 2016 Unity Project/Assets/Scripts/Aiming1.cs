using UnityEngine;
using System.Collections;

public class Aiming1 : MonoBehaviour {
    public int rotMult = 60;

    private GameObject turret;
    private float xRot = 0f;
    private float yRot = 0f;
    Quaternion x;

    void Start()
    {
        turret = GameObject.Find("Tank_Turret_simple1");
    }
    void Update()
    {
        //adjust angle of turret every frame according to player control
        xRot += Input.GetAxis("1RVert") * rotMult * Time.deltaTime;
        yRot += Input.GetAxis("1RHorz") * rotMult * Time.deltaTime;

        x = Quaternion.Euler(new Vector3(xRot, yRot, 0));

        turret.transform.rotation = x;
    }
}