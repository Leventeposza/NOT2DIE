using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 7f;
    public Rigidbody2D rb;
    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer>5)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("player"))
        {
           PlayerLife player = other.gameObject.GetComponent<PlayerLife>();
            if (player !=null)
            {
                player.Die();
            }

            Destroy(gameObject);

        }
        
    }
}
