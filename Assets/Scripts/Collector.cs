using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private float width = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        width = GameObject.Find("BG").GetComponent<BoxCollider2D> ().size.x;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BG" ){
            Vector3 temp = other.transform.position;
            temp.x += width * 3;
            other.transform.position = temp;
        }
        if(other.tag == "Ground" ){
            Vector3 temp = other.transform.position;
            temp.x += width * 3;
            other.transform.position = temp;
        }
}
}
