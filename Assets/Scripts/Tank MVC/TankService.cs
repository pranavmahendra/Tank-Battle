using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonosingletonGeneric<TankService>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("This message is from Tank Service");
    }
}
