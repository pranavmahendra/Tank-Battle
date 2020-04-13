using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnService : MonosingletonGeneric<SpawnService>
{
    public EnemyView _enemyView;
    

    private void Start()
    {
        _enemyView = Resources.Load<EnemyView>("EnemyTank");
        StartCoroutine(spawnEnemy(10));

    }

    private void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Instantiate(_enemyView, new Vector3(12.0f, 0f, -10f), Quaternion.identity);

        yield return new WaitForSeconds(seconds);

        Instantiate(_enemyView, new Vector3(5f, 0f, 17f), Quaternion.identity);

        yield return new WaitForSeconds(seconds);

        Instantiate(_enemyView, new Vector3(2.0f, 0f, -20f), Quaternion.identity);


        yield return new WaitForSeconds(seconds);
    }
}
