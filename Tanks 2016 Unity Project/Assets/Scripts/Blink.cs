using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

    public Renderer text;
    void Start()
    {
        text = GetComponent<Renderer>();
        InvokeRepeating("BeginBlinking", 0, 0.4f);
    }

    IEnumerator BeginBlinking()
    {
        text.enabled = false;
        yield return new WaitForSeconds(0.2f);
        text.enabled = true;
    }
}
