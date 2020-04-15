using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonosingletonGeneric<EnemyService>
{

    private EnemyModel enemyModel;
    public EnemyView enemyView;
    public EnemyController enemyController;

   

    
    public EnemyTankScriptableObject enemyTankScriptableObject;
 
    private void Start()
    {
        
    }

    public EnemyController CreateEnemyTank()
    {
        enemyModel = new EnemyModel(enemyTankScriptableObject);

        enemyController = new EnemyController(enemyModel, enemyView);

        return enemyController;
 
    }



}
