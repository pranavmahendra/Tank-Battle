﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;

public class SpawnService : MonosingletonGeneric<SpawnService>
{

    public EnemyService enemyService;
    private EnemyView enemyView;
    private EnemyController enemyController;

    private Coroutine spawnEnumerator;


    private void Start()
    {
        enemyService = EnemyService.Instance;
       
        spawnEnumerator = StartCoroutine(spawnEnemy(5));


        StopCoroutine(spawnEnumerator);

    }

    private void Update()
    {
        //Random spawning
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //Debug.Log("Spawn when 0 is pressed");

            enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(Random.Range(-11f, 20f), 0f, Random.Range(-8f, 11f)), Quaternion.identity);
        }
    }

    private IEnumerator spawnEnemy(float seconds)
    {


        enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(-13f, 0f, -3.0f), Quaternion.identity);

        yield return new WaitForSeconds(seconds);

        //enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(-38f, 0f, -2f), Quaternion.identity);

        //yield return new WaitForSeconds(seconds);

        //enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(-36f, 0f, -38f), Quaternion.identity);

        //yield return new WaitForSeconds(seconds);

        //enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(26f, 0f, -26f), Quaternion.identity);

        //yield return new WaitForSeconds(seconds);

        //Debug.Log("This coroutine has finished its job.");
    }


}