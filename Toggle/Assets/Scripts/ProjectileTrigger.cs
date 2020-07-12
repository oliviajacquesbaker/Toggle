using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public GameObject bulletPrefab;
    public float speed;
    public int layer;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void FireProjectile()
    {
        Vector3 bulletPos = rigidBody.transform.position + rigidBody.transform.up * 0.8f;
        GameObject bullet = Instantiate(bulletPrefab, bulletPos, rigidBody.transform.rotation);
        bullet.layer = layer;
        bullet.GetComponent<ProjectileBehavior>().speed = speed;
    }
}
