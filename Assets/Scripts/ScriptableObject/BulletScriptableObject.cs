using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObjects")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public float damage;
    public string layer;

}
