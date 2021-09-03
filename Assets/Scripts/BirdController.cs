using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BirdController : MonoBehaviour
{
    [SerializeField] private float velocity = 1;
    [SerializeField] GameState gameState;
    private Rigidbody2D rb;
    private float revSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameState.DisableButton();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
            if (gameState.isStart) 
            {
                jump();
                Debug.Log("Velocity: " + rb.velocity);
                transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * -20);
            }
            else {
                gameState.isStart = true;
                rb.gravityScale = 0.6f;
            }            
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 20);

        }
    }

    public void jump()    {
        
        rb.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Block": GameOver(); break;
            case "Pipes": gameState.UpdateScore(); break;
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        int score = PlayerPrefs.GetInt("score", 0);
        if(gameState.score >= score)
        {
            PlayerPrefs.SetInt("score", gameState.score);            
        }
        gameState.EnbaleButton();
    }
}
