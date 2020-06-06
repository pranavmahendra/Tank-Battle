using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BattleTank.Tank;

public class LevelManager : MonosingletonGeneric<LevelManager>
{
   
    public Scene scene;
    public int index;

    public int tankCode;

    public List<Button> buttons;
    
    // Start is called before the first frame update
    void Start()
    {
   
        buttons[0].onClick.AddListener(tankColorButtons);

        buttons[1].onClick.AddListener(RedColor);
        buttons[2].onClick.AddListener(BlueColor);
        buttons[3].onClick.AddListener(GreenColor);

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(index);
    }

    //Load buttons
    public void tankColorButtons()
    {
        for (int i = 1; i < buttons.Count; i++)
        {

            buttons[i].gameObject.SetActive(true);
            this.tankCode = i;
            buttons[0].gameObject.SetActive(false);
        }
    }

    public void RedColor()
    {
        this.tankCode = 1;
        LoadNextLevel();
    }

    public void BlueColor()
    {
        this.tankCode = 2;
        LoadNextLevel();
    }

    public void GreenColor()
    {
        this.tankCode = 3;
        LoadNextLevel();
    }

}

