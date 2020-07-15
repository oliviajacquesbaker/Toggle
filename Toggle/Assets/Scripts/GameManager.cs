using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private PlayerController player;
    private AIGenerator enemySpawner;

    public GameObject capPointPrefab;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
        enemySpawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<AIGenerator>();

        //countdown?
    }

    void Update()
    {
        
    }

    public void SpawnCapturePoint()
    {
        Vector3 pos = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
        Instantiate(capPointPrefab,pos, Quaternion.identity);
    }

    void StartGame()
    {
        EnablePlayer();
        enemySpawner.StartSpawning();
        player.GetComponent<ProjectileM_F>().Enable();
    }

    void EndGame()
    {
        enemySpawner.StopSpawning();
        player.GetComponent<ProjectileM_F>().Disable();
        DisableEnemies();
        DisablePlayer();
        //bring up end screen
    }

    void EnablePlayer()
    {
        player.enabled = true;
    }

    void DisablePlayer()
    {
        player.enabled = false;
    }

    void DisableEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().enabled = false;
        }
    }
}
