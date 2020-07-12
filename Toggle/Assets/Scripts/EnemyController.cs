using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    private Rigidbody2D rigidBody;
    private ProjectileTrigger projectileTrigger;
    private GameObject target;

    public float speed;
    private bool inRange;
    private float distance;
    private float range;
    private float minRange;
    public bool invincible;

    private float nextFireTime;
    private float period;

    private void Awake()
    {
        gameObject.tag = "enemy";
        gameObject.layer = 10;
    }
    void Start()
    {
        scoreKeeper = (ScoreKeeper)ScoreKeeper.Instance;
        rigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("player");
        projectileTrigger = GetComponent<ProjectileTrigger>();

        projectileTrigger.speed = 4;
        projectileTrigger.layer = 10;
        invincible = false;
        SetSpeed();
        SetDistance();
        SetRange();

        nextFireTime = 0.0f;
        SetPeriod();
    }

    void Update()
    {
        SetDistance();
        if (inRange)
        {
            if (distance >= minRange)
            {
                rigidBody.velocity *= 0.8f;
            }
            else
            {
                rigidBody.velocity *= 0.0f;
            }
            if (Time.time >= nextFireTime)
            {
                projectileTrigger.FireProjectile();
                nextFireTime = Time.time + period;
            }
        }
        else
        {
            Follow();
        }
    }

    void OnBulletHit()
    {
        if (!invincible)
        {
            Destroy(gameObject);
            scoreKeeper.BeatEnemy();
        }
    }

    void ToggleInvincibility()
    {
        invincible = !invincible;
    }

    void Follow()
    {
        rigidBody.velocity = (target.transform.position - transform.position) * speed;
    }

    void SetDistance()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        inRange = (distance <= range);
    }

    void SetRange()
    {
        range = Random.Range(2.5f, 4.5f);
        minRange = Random.Range(0.7f,range - 1.5f);
    }

    void SetSpeed()
    {
        speed = Random.Range(0.15f, 0.25f) * 5;
    }

    void SetPeriod()
    {
        period = Random.Range(0.5f, 2.0f);
    }
}
