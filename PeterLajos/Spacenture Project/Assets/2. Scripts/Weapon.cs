using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource shootingAudio;
    [SerializeField] private AudioClip[] shootingSound;
    public float shootingPitch;

    public Transform firePoint;

    public GameObject bulletPrefab;

    private void Start()
    {
        shootingPitch = Random.Range(1.0f, 3.0f);
    }

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

        // Make sound when shooting
        //shootingAudio.clip = shootingSound;
        shootingAudio.pitch = shootingPitch;
        shootingAudio.Play();
        shootingPitch = Random.Range(0.5f, 1.0f);
    }
}
