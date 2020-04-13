using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EnemyController _enemyController;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void initialize(EnemyController enemyController)
    {
        this._enemyController = enemyController;
    }

}
