using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctahedronShoot : EnemiesStats
{
    private Animator octahedronAttack;

    private const float lowLimitX = -6f;
    private const float highLimitX = 6f;
    private const float lowLimitY = 1.2f;
    private const float highLimitY = 4f;

    Vector2 shipPosition;
    // Start is called before the first frame update  

    private void Start()
    {
        rotationReference = GetComponent<RotateAroundVortex>();
        octahedronAttack = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SetTimer(timetillmove, () => Move());
        timetillmove = 2f;
        timer = 0;
        ship = GameObject.FindGameObjectWithTag("Player");
        Addedforce = 425;
    }

    // Update is called once per frame
    void Update()
    {        
        TimerStart();
    }

    private new void Shoot()
    {
        AudioManager.inst.Play("ShootEnemy");
        shipPosition = (ship.transform.position - transform.position).normalized;
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(shipPosition * Addedforce);
        SetTimer(timetillmove, () => Move());
    }

    private new void Move() {
        octahedronAttack.SetTrigger("Attack");
        if (!rotationReference.IntoTheVortex)
        {
            randomPositionX = Random.Range(lowLimitX, highLimitX);
            randomPositionY = Random.Range(lowLimitY, highLimitY);
            transform.position = new Vector2(randomPositionX, randomPositionY);
        }        
        
    }
}
