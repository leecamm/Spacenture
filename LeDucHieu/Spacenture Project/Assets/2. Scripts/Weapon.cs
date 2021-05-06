﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    

    // Update is called once per frame
    void Update()
    {
        if(CounterForShootingParts.collectedPartsAmount >= 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}