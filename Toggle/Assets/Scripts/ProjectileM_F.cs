using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileM_F : MonoBehaviour
{
    private ProjectileTrigger projectileTrigger;

    private float nextFireTime;
    [SerializeField]
    private float period;

    void Start()
    {
        projectileTrigger = GetComponent<ProjectileTrigger>();
        projectileTrigger.speed = 5;
        projectileTrigger.layer = 9;

        nextFireTime = 0.0f;
    }

    
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (Input.GetMouseButton(0))
            {
                projectileTrigger.FireProjectile();
                nextFireTime = Time.time + period;
            }
        }
    }
}
