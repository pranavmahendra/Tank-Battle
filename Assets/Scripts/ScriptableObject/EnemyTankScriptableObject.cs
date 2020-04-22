using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTankScriptableObject")]
public class EnemyTankScriptableObject: ScriptableObject
{
   public EnemyType enemyType;
   public float speed;
   public float health;
}