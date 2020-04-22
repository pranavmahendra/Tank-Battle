﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList" , menuName = "ScriptableObjects/NewTankScriptableObjectList")]
public class TankScriptableObjectList: ScriptableObject
{
    public TankScriptableObjects[] tanks;
}