using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnService : MonosingletonGeneric<SpawnService>
{

    public EnemyService enemyService;
    private EnemyView enemyView;

    private IEnumerator spawnEnumerator;


    private void Start()
    {
        enemyService = EnemyService.Instance;
        spawnEnumerator = spawnEnemy(5);


        StartCoroutine(spawnEnumerator);

    }

    private void Update()
    {
        //Random spawning
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Spawn when S is pressed");
            SpawnEnemyTank(new Vector3(Random.Range(-11f, 20f), 0f, Random.Range(-8f, 11f)), Quaternion.identity);
        }
    }

    private IEnumerator spawnEnemy(float seconds)
    {
        
        SpawnEnemyTank(new Vector3(-11f, 0f, 11f) , Quaternion.identity);

        yield return new WaitForSeconds(seconds);

        SpawnEnemyTank(new Vector3(6f, 0f, -12f), Quaternion.identity);

        Debug.Log("This coroutine has finished its job.");
    }


    //Controller creation method.
    public void SpawnEnemyTank(Vector3 enemySpawnerPos, Quaternion enemyRotation)
    {
        EnemyModel model = new EnemyModel(enemyService.enemyTankScriptableObject);
        EnemyController enemyController = new EnemyController(model, enemyService.enemyView);

        enemyService.enemyView.transform.position = enemySpawnerPos;
        enemyService.enemyView.transform.rotation = enemyRotation;
        
    }

    
}
