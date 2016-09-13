using UnityEngine;
using System.Collections;

public class Tree_1_Behavior : MonoBehaviour {

    public Mesh Swap;

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Tree collision");
        gameObject.GetComponent<MeshFilter>().mesh = Swap;
        //DestroyObject(gameObject);
    }
}
