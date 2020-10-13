using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Game vars
    public int coins;
    public int maxCoins;
    public int kills;
    public int maxKills;
    public bool gameOver;
    public bool scoreReached;
    private GameObject finalStair;

    // Start is called before the first frame update
    void Awake()
    {
        coins = 0;
        maxCoins = 7;
        kills = 0;
        maxKills = 13;
        gameOver = false;
        scoreReached = false;
        finalStair = GameObject.FindGameObjectWithTag("FinalStair");
        GameObject.FindGameObjectWithTag("FinalStair").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == maxCoins && kills == maxKills)
        {
            //set the staircase active
            scoreReached = true;
        }
        if (scoreReached)
        { 
            finalStair.SetActive(true);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
