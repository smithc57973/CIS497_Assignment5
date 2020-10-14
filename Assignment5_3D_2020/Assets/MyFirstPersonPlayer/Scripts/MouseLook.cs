/*
 * Chris Smith
 * Assignment53D
 * Controls camera movement via mouse
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Reference to player
    public GameObject player;
    //Reference to game manager
    public GameManager gameManager;
    //Player look sensitivity
    public float mouseSens = 100f;
    //Default look rotation
    private float verticalLookRotation = 0f;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            //Get mouse input and assign
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            //Rotate Player with horizontal mouse input
            player.transform.Rotate(Vector3.up * mouseX);

            //Rotate camera around x axis with vertical mouse input
            verticalLookRotation -= mouseY;

            //Clamp rotation
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

            //Apply rotation to camera based on clamped output
            transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        //Locks the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }
}
