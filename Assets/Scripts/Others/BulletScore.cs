using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank.EnemyTank;
using BattleTank.Tank;
using UnityEngine.UI;
using BattleTank.bullet;
using TMPro;

public class BulletScore : MonoBehaviour
{
    private TextMeshProUGUI bulletsFiredText;
    public TankView tankView;

    private int bullets = 0;

    void Start()
    {
         bulletsFiredText = GetComponent<TextMeshProUGUI>();

        followPlayer();


    }


    private void LateUpdate()
    {
        tankView.onBulletFire += BulletScore_OnBulletFire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void followPlayer()
    {

        tankView = TankService.Instance.tankLists[0].TankView;

    }

    private void BulletScore_OnBulletFire()
    {
        bullets += 1;
        bulletsFiredText.text = "Bullets Fired: " + bullets;

    }




}
