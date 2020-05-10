using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;
using BattleTank.EnemyTank;
using BattleTank.Tank;
using System;

public class AudioService : MonosingletonGeneric<AudioService>
{

    public List<AudioSource> audioSources;
   
    public List<AudioClip> bulletSounds;
    public AudioClip tankExplosion;

    // Start is called before the first frame update
    void Start()
    {
        ////Initialization
        //audioSources[0] = GetComponent<AudioSource>();
        //audioSources[1] = GetComponent<AudioSource>();

        //Listeners
        BulletService.Instance.onBulletCreated += BV_BulletCreated;
        BulletService.Instance.onBulletDestroy += BV_BulletDestroy;

        EnemyService.Instance.onDeathEvent += EV_EnemyDestroy;

        TankService.Instance.onDeathofPlayer += TV_TankDestroy;

    }

    private void TV_TankDestroy()
    {
        audioSources[1].clip = tankExplosion;
        audioSources[1].Play();
    }

    private void EV_EnemyDestroy()
    {
        audioSources[1].clip = tankExplosion;
        audioSources[1].Play();
    }

    private void BV_BulletDestroy()
    {
        audioSources[0].clip = bulletSounds[1];
        audioSources[0].Play();
    }

    private void BV_BulletCreated()
    {
        audioSources[0].clip = bulletSounds[0];
        audioSources[0].Play();
    }



}
