using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject livesScreen;
    public TextMeshProUGUI livesText;
    public GameObject endScreen;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI infoText;
    public KeyCode keyUp;
    public KeyCode keyLeft;
    public KeyCode keyDown;
    public KeyCode keyRight;
    private float speed = 0.6f;
    private int lives = 100;
    private bool gameEnd = false;
    private float timeLeft = 24.3f;
    void EndGame(bool won)
    {
        gameEnd = true;
        livesScreen.SetActive(false);
        endScreen.SetActive(true);
        statusText.text = "You " + (won ? "won!" : "lost.");
        infoText.text = "You " + (won ? "won with " + lives.ToString() + " lives!" : "lost with " + timeLeft.ToString() + "s remaining.");
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && !gameEnd)
        {
            EndGame(true);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(keyUp))
            GetComponent<Rigidbody>().velocity += new Vector3(speed, 0, 0);
        if (Input.GetKey(keyDown))
            GetComponent<Rigidbody>().velocity -= new Vector3(speed, 0, 0);
        if (Input.GetKey(keyLeft))
            GetComponent<Rigidbody>().velocity += new Vector3(0, 0, speed);
        if (Input.GetKey(keyRight))
            GetComponent<Rigidbody>().velocity -= new Vector3(0, 0, speed);
    }
    void OnParticleCollision(GameObject other)
    {
        lives -= 1;
        livesText.text = lives.ToString();
        if (lives == 0 && !gameEnd)
        {
            EndGame(false);
        }
    }
}
