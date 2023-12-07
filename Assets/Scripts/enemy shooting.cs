using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;

    private float timer;
    private GameObject player;
    public AudioSource shoot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    
    public void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }

           
    }

    public void Shoot()
    {
        shoot.Play();
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }
}
