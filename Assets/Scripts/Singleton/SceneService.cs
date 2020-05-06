using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleTank.Tank;
using BattleTank.EnemyTank;
using UnityEngine.UI;
using System;

public class SceneService : MonosingletonGeneric<SceneService>
{
    //Whenever gameobject with tankview collides with enemyview scene will restart.
    //access to tankview.
    //access to enemeyview.

    public TankView tankView;
    private AudioSource audioSource;
    public EnemyView enemyView;

    public Button restartButton;
    public Button MainMenu;

    public GameObject gameoverCanvas;

    public Scene scene;
    public int sceneIndex;


    private void Start()
    {
        //Initialization
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        audioSource = tankView.GetComponent<AudioSource>();

        //Subscribing events.
        TankService.Instance.onDeathofPlayer += sceneService_restart;
        //Debug.Log("Message from scene service " + TankService.Instance.tankLists.Count);

        //Button Clicks
        restartButton.onClick.AddListener(sceneRestart);
        MainMenu.onClick.AddListener(MainMenuLoader);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void sceneService_restart()
    {
        GameOverScreen(); 
    }

    public void followPlayer()
    {
        tankView = TankService.Instance.tankLists[0].TankView;
    }
    
    public void followEnemey()
    {
        foreach(EnemyController enemyController in EnemyService.Instance.enemyList)
        {
            this.enemyView = enemyController.EnemyView;
  
        }
    }

    public void GameOverScreen()
    {
        gameoverCanvas.SetActive(true);
        audioSource.enabled = false;
        //StartCoroutine(restart(3));
    }

    private void sceneRestart()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void MainMenuLoader()
    {
        SceneManager.LoadScene(0);
    }

    ////on Touching
    //private IEnumerator restart(float seconds)
    //{
        
    //    Debug.Log("GAME OVER");
    //    yield return new WaitForSeconds(seconds);
    //    SceneManager.LoadScene(sceneIndex);
        
    //}

}
