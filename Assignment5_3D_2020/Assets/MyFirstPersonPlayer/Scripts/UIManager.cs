/*
 * Chris Smith
 * Assignment53D
 * Controls UI elements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI vars
    public Text coinScore;
    public Text killScore;
    public Text goalText;
    public Text winText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        coinScore.text = "Coins: 0 / " + gameManager.maxCoins;
        killScore.text = "Kills: 0 / " + gameManager.maxKills;
        winText.enabled = false;
        StartCoroutine(fadeTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        //display score until game is over
        if (!gameManager.gameOver)
        {
            coinScore.text = "Coins: " + gameManager.coins + " / " + gameManager.maxCoins;
            killScore.text = "Kills: " + gameManager.kills + " / " + gameManager.maxKills;
        }
    }

    private IEnumerator fadeTutorial()
    {
        yield return new WaitForSeconds(10);
        goalText.enabled = false;
    }
}
