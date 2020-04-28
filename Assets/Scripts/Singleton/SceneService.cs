using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BattleTank.Tank;
using BattleTank.EnemyTank;

public class SceneService : MonosingletonGeneric<SceneService>
{
    //Whenever gameobject with tankview collides with enemyview scene will restart.
    //access to tankview.
    //access to enemeyview.

    public TankView tankView;

    public EnemyView enemyView;


    public Scene scene;
    public int sceneIndex;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex; 
        
        

        Debug.Log("Message from scene service " + TankService.Instance.tankLists.Count);

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

    public void sceneRestart()
    { 
        StartCoroutine(restart(3));
    }

    private IEnumerator restart(float seconds)
    {
        Debug.Log("Player has collided with enemy tank. GAME OVER");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
        
    }
     
}
