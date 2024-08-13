using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    private float playerMovementSpeed = 3f;
    private Button shifter;
    private Rigidbody2D rb;
    private TextMeshProUGUI score;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shifter = GameObject.Find("Shifter").GetComponent<Button>();
        shifter.onClick.AddListener(shiftGravity);
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = "0";
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Rocket"){
            StartCoroutine(KillPlayerAndRestartGame());
        }
        if(other.tag == "Coin"){
            score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
     IEnumerator KillPlayerAndRestartGame(){
        transform.position = new Vector3(200,200,0);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }
}