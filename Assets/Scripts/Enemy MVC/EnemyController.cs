using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public EnemyController(EnemyModel enemyModel, EnemyView EnemyPrefab)
    {
        EnemyModel = enemyModel;

        EnemyView = GameObject.Instantiate<EnemyView>(EnemyPrefab);

        EnemyView.initialize(this);
        
    }

    public EnemyModel EnemyModel { get; }
    public EnemyView EnemyView { get; }

    public EnemyModel getModel()
    {
        return EnemyModel;
    }


}
