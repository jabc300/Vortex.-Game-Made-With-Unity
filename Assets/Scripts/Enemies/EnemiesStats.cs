using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesStats : MonoBehaviour
{
    //GameObject Bullet;
    protected Action timerEndsAction;

    protected RotateAroundVortex rotationReference;

    protected GameObject instantiatedBullet;
    protected GameObject ship;

    protected Vector2 target;

    public float Addedforce;
    public float timetillmove;

    protected float randomPositionX;
    protected float randomPositionY;
    protected float timer;
    protected float timeTillShoot;

    protected bool TrappedInTheVortex;
    protected bool lockTime;

    public float speed;
    protected float correctedSpeed;

    private void Start()
    {
        rotationReference = GetComponent <RotateAroundVortex>();
    }

    protected void SetTimer(float timer, Action timerEndsAction) {

        this.timer = timer;
        this.timerEndsAction = timerEndsAction;
    }

    protected void TimerStart()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) timerEndsAction();
        }
    }

    public void Move()
    {
        Debug.Log("Move The Enemy");
    }

    public void Shoot()
    {
        Debug.Log("The Enemy Shoot");
    }

}
