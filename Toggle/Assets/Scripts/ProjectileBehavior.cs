using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.isKinematic = true;
    }

    void Update()
    {
        transform.Translate(rigidBody.transform.up * Time.deltaTime * speed, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("OnBulletHit");
        Destroy(gameObject);
    }
}
