using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;

public class EnemyView : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BulletView>() != null)
        {
            Debug.Log("Enemy tank has been destroyed.");
            Destroy(gameObject);
        }
    }
}
