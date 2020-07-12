using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileM_F : MonoBehaviour
{
    private ProjectileTrigger projectileTrigger;

    void Start()
    {
        projectileTrigger = GetComponent<ProjectileTrigger>();
        projectileTrigger.speed = 5;
        projectileTrigger.layer = 9;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projectileTrigger.FireProjectile();
        }
    }
}
