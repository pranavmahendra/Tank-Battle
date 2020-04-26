using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ServiceEvents : MonosingletonGeneric<ServiceEvents>
{
    public event Action onDeathEvent;

    public event Action onBulletHit;

    private void Start()
    {
        
    }

    public void onDeathBroadcast()
    {
        onDeathEvent?.Invoke();
    }

    public void onBulletBroadcast()
    {
        onBulletHit?.Invoke();
    }
}
