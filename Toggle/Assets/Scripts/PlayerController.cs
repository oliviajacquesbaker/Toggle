using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string axisHorizontal;
    [SerializeField]
    private string axisVertical;
    [SerializeField]
    private Sprite vulnerableSprite;
    [SerializeField]
    private Sprite invincibleSprite;

    private Rigidbody2D rigidBody;
    public float speed;
    private bool invincible;

    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;

    private void Awake()
    {
        gameObject.tag = "player";
    }
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = (GameManager)GameManager.Instance;
        invincible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis(axisHorizontal);
        float movementVertical = Input.GetAxis(axisVertical);
        Vector2 movement = new Vector2(movementHorizontal, movementVertical);
        rigidBody.velocity = movement*speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            invincible = !invincible;
            ToggleEnemyInvincibility();
            if (invincible)
            {
                spriteRenderer.sprite = invincibleSprite;
            }
            else
            {
                spriteRenderer.sprite = vulnerableSprite;
            }
        }
    }

    void OnBulletHit()
    {
        if (!invincible)
        {
            gameManager.SendMessage("EndGame");
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    void ToggleEnemyInvincibility()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i=0; i<enemies.Length; i++)
        {
            enemies[i].SendMessage("ToggleInvincibility");
        }

    }

    public bool isInvincible()
    {
        return invincible;
    }
}
