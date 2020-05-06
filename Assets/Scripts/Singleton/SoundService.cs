using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.bullet;
using System;

public class SoundService : MonosingletonGeneric<SoundService>
{
    public List<AudioClip> bulletClips;
    public List<AudioSource> audioSources;

    public BulletView bulletView;


    private void Start()
    {
        BulletService.Instance.onBulletDestroy += sound_OnBulletDestroy;
    }

    private void sound_OnBulletDestroy()
    {
        Debug.Log("Bullet Destoryed play sound");
        audioSources[0].clip = bulletClips[2];
        audioSources[0].Play();
    }

    public void soundInitialzation()
    {
        for (int i = 0; i < BulletService.Instance.bulletsCreated.Count; i++)
        {
            bulletView = BulletService.Instance.bulletsCreated[i].BulletView;
            audioSources[0] = bulletView.GetComponent<AudioSource>();
        }
    }

    public void bulletShot()
    {
        audioSources[0].clip = bulletClips[1];
        audioSources[0].Play();
    }

 
}
