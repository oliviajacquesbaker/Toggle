using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    private Rigidbody2D rigidBody;
    private GameObject player;
    private SpriteRenderer sprite;
    private Color red, green;
    private float goalTime;
    private float captureTime;
    private bool onTarget;

    public float captureProgress { get => captureTime / goalTime; }

    void Start()
    {
        scoreKeeper = (ScoreKeeper)ScoreKeeper.Instance;
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        sprite = GetComponent<SpriteRenderer>();
        green = new Color(162/255.0f, 241/255.0f, 194/255.0f,1);
        red = new Color(241/255.0f, 162/255.0f, 162/255.0f,1);
        rigidBody.isKinematic = true;
        goalTime = 350;
    }

    void FixedUpdate()
    {
        if (captureTime >= goalTime)
        {
            PointCaptured();
        }
        if (onTarget)
        {
            if (player.GetComponent<PlayerController>().isInvincible()) 
            { 
                onTarget = false;
                sprite.color = red;
            }
            else
            {
                captureTime += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            if (!other.GetComponent<PlayerController>().isInvincible())
            {
                sprite.color = green;
                onTarget = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            sprite.color = red;
            onTarget = false;
        }
    }

    void PointCaptured()
    {
        Destroy(gameObject);
        scoreKeeper.CapturePoint();
    }

}
