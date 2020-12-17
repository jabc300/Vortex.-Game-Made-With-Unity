using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondEnemyShoot : EnemiesStats
{
    private Animator rotateDiamond;

   void Start()
    {
        rotationReference = GetComponent<RotateAroundVortex>();
        rotateDiamond = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SetTimer(timetillmove, () => Move());
        TrappedInTheVortex = false;
        timetillmove = 2f;
        timer = 0;
        speed = 5;
        Addedforce = 300;
        randomPositionX = Random.Range(-6f, 6f);
        randomPositionY = Random.Range(1f, 4f);
        target = new Vector2(randomPositionX, randomPositionY);
    }

    // Update is called once per frame
    void Update()
    {

        TimerStart();
        if (!rotationReference.IntoTheVortex)
        {
            correctedSpeed = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
        }

    }

    private new void Shoot() {
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((-transform.up + transform.right * 0.5f) * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((-transform.up - transform.right * 0.5f) * Addedforce);
        SetTimer(timetillmove, () => Move());
    }

    private new void Move()
    {
        rotateDiamond.SetTrigger("Attack");
        if (!rotationReference.IntoTheVortex)
        {
            randomPositionX = Random.Range(-6f, 6f);
            randomPositionY = Random.Range(1.2f, 4f);
            target = new Vector2(randomPositionX, randomPositionY);           
        }
            
            
    }
   
}
