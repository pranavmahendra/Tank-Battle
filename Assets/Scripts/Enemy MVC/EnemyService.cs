using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonosingletonGeneric<EnemyService>
{

    private EnemyModel _enemyModel;
    public EnemyView _enemyView;
    private EnemyController _enemyController;

    [SerializeField]
    private EnemyTankScriptableObject enemyTankScriptableObject;
 
    private void Start()
    {


        CreateEnemyTank();
    }

    public EnemyController CreateEnemyTank()
    {
        _enemyModel = new EnemyModel(enemyTankScriptableObject);

        _enemyController = new EnemyController(_enemyModel, _enemyView);

        return _enemyController;
 
    }



}
