using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private float width = 0f;

    void Awake()
    {
        width = GameObject.Find("BG").GetComponent<BoxCollider2D> ().size.x;
    }

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
