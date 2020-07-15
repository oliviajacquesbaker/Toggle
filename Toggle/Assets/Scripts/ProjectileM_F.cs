using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileM_F : MonoBehaviour
{
    private ProjectileTrigger projectileTrigger;

    private float nextFireTime;
    [SerializeField]
    private float period;
    private bool gameActive;

    void Start()
    {
        projectileTrigger = GetComponent<ProjectileTrigger>();
        projectileTrigger.speed = 5;
        projectileTrigger.layer = 9;

        nextFireTime = 0.0f;
        gameActive = true; //only for testing, this needs to be FALSE
    }

    
    void Update()
    {
        if (gameActive)
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

    public void Disable()
    {
        gameActive = false;
    }

    public void Enable()
    {
        gameActive = true;
    }
}
