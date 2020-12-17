using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : EnemiesStats
{

    public Transform ShootingPosition;
    // Start is called before the first frame update
    void Start()
    {
        rotationReference = GetComponent<RotateAroundVortex>();
        SetTimer(timeTillShoot, () => Shoot());
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        SetTimer(timeTillShoot, () => Shoot());
        timer = 0;
        timeTillShoot = 0.8f;
        TrappedInTheVortex = false;
        Addedforce = 300;
        speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        correctedSpeed = speed * Time.deltaTime;        
        Move();
    }

    private new void Move()
    {
        target = new Vector2(ship.transform.position.x, transform.position.y);
        TimerStart();
        if (!rotationReference.IntoTheVortex)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
        }
    }

    private new void Shoot() {
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", ShootingPosition.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        SetTimer(timeTillShoot, () => Shoot());
    }

}
