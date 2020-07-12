using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransform_E : MonoBehaviour
{
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        float xDir = target.GetComponent<Rigidbody2D>().transform.position.x - transform.position.x;
        float yDir = target.GetComponent<Rigidbody2D>().transform.position.y - transform.position.y;
        Vector2 direction = new Vector2(xDir, yDir);

        transform.up = direction;
    }
}