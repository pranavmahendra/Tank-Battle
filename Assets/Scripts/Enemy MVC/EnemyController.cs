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

    public void EnemyZMovement()
    {
        EnemyView.transform.Translate(new Vector3(0f, 0f, 1f) * EnemyModel.Speed * Time.deltaTime);
    }

    


}
