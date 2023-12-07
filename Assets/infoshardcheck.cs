using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoshardcheck : MonoBehaviour
{
    public GameObject textresult;
    public GameObject textresult2;

    void Start()
    {


        int shard = PlayerPrefs.GetInt("shardsgot");

        if(shard ==1)
        {
            textresult.SetActive(true); 
            
        }
        else { textresult2.SetActive(true); }
    }
}
