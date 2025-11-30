using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private int highScore;
    private float playerMovementSpeed = 3f;
    private Button shifter;
    private Rigidbody2D rb;
    private TextMeshProUGUI score;
    public AudioClip coinCollectClip;
    public AudioClip aestroidHitClip;
    public AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shifter = GameObject.Find("Shifter").GetComponent<Button>();
        shifter.onClick.AddListener(shiftGravity);
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        score.text = "0";
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

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
        if (other.tag == "Aestroid")
        {
            audioSource.PlayOneShot(aestroidHitClip);
            StartCoroutine(KillPlayerAndRestartGame());
        }
        if(other.tag == "Coin"){
            audioSource.PlayOneShot(coinCollectClip);
            other.gameObject.SetActive(false);
            score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
     IEnumerator KillPlayerAndRestartGame(){
        int currentScore = int.Parse(score.text);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        transform.position = new Vector3(200,200,0);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }
}
//MainMenu Icon
//<a href="https://www.flaticon.com/free-icons/quit" title="quit icons">Quit icons created by SBTS2018 - Flaticon</a>
//MainMenu BG Music
//Sound Effect by <a href="https://pixabay.com/users/van_wiese-19197905/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=8970">van_Wiese</a> from <a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=8970">Pixabay</a>
//Aestroid Impact Sound
//Sound Effect by <a href="https://pixabay.com/users/lordsonny_two-43606937/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=253779">LordSonny Two</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=253779">Pixabay</a>
//Aestroid Png
//<a href="https://www.freepik.com/free-psd/isolated-dark-grey-asteroid-3d-render-space-rock_409843503.htm">Image by tohamina on Freepik</a>
//Gameplay BG Music
//Sound Effect by <a href="https://pixabay.com/users/lucadialessandro-25927643/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=295434">Luca Di Alessandro</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=295434">Pixabay</a>
//Coin Collect Sound
//Sound Effect by <a href="https://pixabay.com/users/freesound_community-46691455/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=14631">freesound_community</a> from <a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=14631">Pixabay</a>