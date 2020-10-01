/*
* Chris Smith
* Assignment 5
* Controls UI and score
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text endText;
    public PlayerPlatformerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        endText = FindObjectOfType<Text>();
        endText.gameObject.SetActive(false);
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (pc.gameOver && pc.won)
        {
            endText.text = "You Win!\nPress R to restart";
            endText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (pc.gameOver && !pc.won)
        {
            endText.text = "You Lose!\nPress R to restart";
            endText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}
