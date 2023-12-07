using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    private void Awake()
    {
        instance = this;
    }

    private Animator anim;
    private Rigidbody2D rb;
    public bool IsAlive;
    public AudioSource waaaa;
    public AudioSource explodeondeath;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        IsAlive = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        if(collision.gameObject.CompareTag("Border"))
        {
            Fall();
        }
    }
    public void Die()
    {
        explodeondeath.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void Fall()
    {
       
        IsAlive = false;
        waaaa.enabled= true;
        StartCoroutine(restarttimer());
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator restarttimer()
    {
        yield return new WaitForSeconds(4f);
        RestartLevel();
    }
}
