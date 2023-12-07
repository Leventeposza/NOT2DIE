using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public AudioSource shoot;



    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && PauseMenu.GameIsPaused != true)
        {
            Shoot();

        }
    }

    public void Shoot()
    {
        shoot.Play();
        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
    }
}
