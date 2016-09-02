using UnityEngine;
using System.Collections;

public class Aiming3 : MonoBehaviour
{
    public int rotMult = 60;


    private GameObject turret;
    private float xRot = 0f;
    private float yRot = 0f;


    void Start()
    {
        turret = GameObject.Find("Tank_Turret_simple3");
    }
    void Update()
    {
        xRot += Input.GetAxis("3RVert") * rotMult * Time.deltaTime;
        yRot += Input.GetAxis("3RHorz") * rotMult * Time.deltaTime;

        turret.transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot, 0));
    }
}