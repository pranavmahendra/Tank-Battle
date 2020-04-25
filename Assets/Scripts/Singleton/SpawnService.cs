using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;

public class SpawnService : MonosingletonGeneric<SpawnService>
{

    public EnemyService enemyService;
    private EnemyView enemyView;

    private Coroutine spawnEnumerator;


    private void Start()
    {
        enemyService = EnemyService.Instance;
        if (spawnEnumerator != null)
        {
            StopCoroutine(spawnEnumerator);
        }


        spawnEnumerator = StartCoroutine(spawnEnemy(5));

    }

    private void Update()
    {
        //Random spawning
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Spawn when 0 is pressed");

            enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(Random.Range(-11f, 20f), 0f, Random.Range(-8f, 11f)), Quaternion.identity);
        }
    }

    private IEnumerator spawnEnemy(float seconds)
    {


        enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(-11f, 0f, 11f), Quaternion.identity);

        yield return new WaitForSeconds(seconds);

        //enemyService.CreateEnemyTank().setPositionEnemy(new Vector3(6f, 0f, -13f), Quaternion.identity);


        Debug.Log("This coroutine has finished its job.");
    }


}