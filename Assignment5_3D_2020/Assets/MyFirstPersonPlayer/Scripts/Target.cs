/*
 * Chris Smith
 * Assignment53D
 * Controls target health
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;
    //Targetable objects health
    public float health = 50f;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManager>();
    }

    //On taking damage
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    //On death
    void Die()
    {
        Destroy(gameObject);
        gameManager.kills++;
    }
}
