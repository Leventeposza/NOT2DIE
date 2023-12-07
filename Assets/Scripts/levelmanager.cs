using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    int levelIsUnlocked;

    public Button[] buttons;
    
    private void Awake()
    {
        Buttonreset();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            clearsave();
        }
    }

    private void Buttonreset()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (unlockedLevel > 2)
        {
            unlockedLevel = 2;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            
            buttons[i].interactable = true;
        }
    }

    public void openLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }


   
    public void clearsave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        Buttonreset();
    }
}
