using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransform_F : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        float xDir = mousePos.x - transform.position.x;
        float yDir = mousePos.y - transform.position.y;
        Vector2 direction = new Vector2(xDir, yDir);

        transform.up = direction;
    }
}
