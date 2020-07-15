using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject player;
    WaitForSeconds wfs = new WaitForSeconds(2f);
    private float xPos, yPos;
    private float[][] spawnAreas;
    private int enemyCount;
    void Start()
    {
        spawnAreas = new float[3][];
        SetRange();
        player = GameObject.FindGameObjectWithTag("player");

        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SetPos();
            Vector3 pos = new Vector3(xPos, yPos, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            if (player.GetComponent<PlayerController>().isInvincible())
            {
                newEnemy.GetComponent<EnemyController>().invincible = true;
            }
            yield return wfs;
        }

    }

    void SetRange()
    {
        spawnAreas[0] = new float[] { -6, -4, -4.5f, 4.5f };
        spawnAreas[1] = new float[] { -6, 6, 3, 4.5f };
        spawnAreas[2] = new float[] { 4, 6, -4.5f, 4.5f };
    }
    void SetPos()
    {
        int area = Random.Range(0, 3);
        if (area == 3) { area = 2; }
        xPos = Random.Range(spawnAreas[area][0], spawnAreas[area][1]);
        yPos = Random.Range(spawnAreas[area][2], spawnAreas[area][3]);
    }
}
