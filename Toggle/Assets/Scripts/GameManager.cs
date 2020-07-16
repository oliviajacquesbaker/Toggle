using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private PlayerController player;
    private AIGenerator enemySpawner;
    private ScoreHolder scoreHolder;
    [SerializeField]
    private GameObject playerPrefab;
    
    
    [SerializeField]
    private GameObject capPointPrefab;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
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
        scoreHolder = (ScoreHolder)ScoreHolder.Instance;
        scoreHolder.Reset();
        gameObject.tag = "manager";
        //countdown?
    }

    public void SpawnCapturePoint()
    {
        Vector3 pos = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
        Instantiate(capPointPrefab,pos, Quaternion.identity);
    }

    public void StartGame()
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
        scoreHolder.UpdateScores();
        SceneManager.LoadScene("EndScreen");
        
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

    

    public void Reset()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        Vector3 playerPos = new Vector3(0, 0);
        Instantiate(playerPrefab,playerPos, Quaternion.identity);
    }
}
