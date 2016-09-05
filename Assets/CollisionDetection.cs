using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

    //Collision detection
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision detected");
        if (col.gameObject.tag == "obstacle")
        {
            Debug.Log("Collision detected");
        }
    }
}
