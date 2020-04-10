using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BulletScriptableoObjectList", menuName = "ScriptableObjects/NewBulletScriptableObjectList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}