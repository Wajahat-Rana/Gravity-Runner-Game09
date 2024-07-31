using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMovement : MonoBehaviour
{

    private float playerMovementSpeed = 3f;
    private Button shifter;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shifter = GameObject.Find("Shifter").GetComponent<Button>();
        shifter.onClick.AddListener(shiftGravity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += playerMovementSpeed * Time.deltaTime;
        transform.position = temp;
    }
    void shiftGravity()
    {
        rb.gravityScale *= -1;
        Vector3 temp = rb.transform.localScale;
        temp.y *= -1;
        rb.transform.localScale = temp;
    }
}