using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransform_F : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        float xDir = mousePos.x - transform.position.x;
        float yDir = mousePos.y - transform.position.y;
        Vector2 direction = new Vector2(xDir, yDir);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        rigidBody.MoveRotation(angle - transform.rotation.z -90);
    }


}
