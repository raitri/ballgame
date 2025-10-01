using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text scoreText;
    public TMP_Text winText;
    public GameObject gate;
    private Rigidbody rb;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetscoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement=new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //Restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Quit level
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetscoreText();
            if(score >= 10)
            {
                gate.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("danger"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void SetscoreText()
    {
        scoreText.text="Score: "+score.ToString();

        if(score >= 15)
        {
            winText.text = "You win! Press R to restart or ESC to exit";
        }
    }
}
