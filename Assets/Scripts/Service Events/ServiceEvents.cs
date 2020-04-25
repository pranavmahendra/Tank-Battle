using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ServiceEvents : MonosingletonGeneric<ServiceEvents>
{
    public event Action onDeathEvenet;

    public event Action onBulletHit;

    private void Start()
    {
        onDeathEvenet?.Invoke();
        onBulletHit?.Invoke();
    }
}
