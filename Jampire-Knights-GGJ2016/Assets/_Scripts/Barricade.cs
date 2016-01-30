﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Barricade : MonoBehaviour
{
    Health healthManager;

    void Start()
    {
        healthManager = GetComponent<Health>();
    }

    void Update()
    {
        if (healthManager.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
