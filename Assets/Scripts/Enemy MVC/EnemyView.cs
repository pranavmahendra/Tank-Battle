using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;

public class EnemyView : MonoBehaviour, IDamagable
{
    public EnemyController enemyController;
    public Rigidbody rb3d;

    private void Start()
    {
        
    }

    private void Update()
    {
        //_enemyController.EnemyZMovement();
    }

    public void initialize(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    //Destroy enemy on collision with bullet.

    public void TakeDamage(BulletType bullettype, int damage)
    {
        Debug.Log("Taking damage " + damage);
        enemyController.ApplyDamage(damage);
    }
}
