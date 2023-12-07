using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
    
{   public static ItemCollector instance;

    public bool firstLevel;

    public int levelnumber;

    private int InfoShard = 0;

    public int expectedshard;

    public TMP_Text InfoShardText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        if(firstLevel ==true)
        {
            PlayerPrefs.DeleteKey("InfoShard");
        }
        AllPickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("pickUP"))
        {
            
            
            switch (levelnumber)
            {
                case 1:
                    if (InfoShard < expectedshard)
                    {
                        PickUp();
                        Destroy(collision.gameObject);
                    }
                    else { Destroy(collision.gameObject); }
                    break;
                case 2:
                    if (InfoShard < expectedshard)
                    {
                        PickUp();
                        Destroy(collision.gameObject);
                    }
                    else { Destroy(collision.gameObject); }
                    break;

                default: break;
            }
        }
    }
    private void PickUp()
    {
        
        InfoShard++;
        PlayerPrefs.SetInt("InfoShard", InfoShard);
        AllPickUp();
    }

    public void AllPickUp()
    {
        InfoShard = PlayerPrefs.GetInt("InfoShard", 0);

        InfoShardText.text = "Info Shards: " + InfoShard;

    }

   public void checkshard()
    {
        if (InfoShard >= 5)
        {
            PlayerPrefs.SetInt("shardsgot", 1);
        }
       
    }

    public void Update()
    {
        checkshard();
    }

}
