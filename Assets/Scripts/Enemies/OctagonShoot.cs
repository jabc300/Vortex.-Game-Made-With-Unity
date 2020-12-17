using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OctagonShoot : EnemiesStats
{
    public float rotationDegrees;
    private bool pointSelected;
    public GameObject device;
    private Life lifeComponent;

    private void OnEnable()
    {
        lifeComponent = GetComponent<Life>();
        SetTimer(timeTillShoot, () => Shoot());        
        Addedforce = 200;
        timeTillShoot = 0.7f;
        pointSelected = false;
    }

    private void OnDisable()
    {
        Invoke("Retrieve", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        correctedSpeed = speed * Time.deltaTime;       
        Move();
    }

    private new void Shoot()
    {
        AudioManager.inst.Play("ShootEnemy");

        //SHOOT DOWN-------------------------
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((-transform.up + transform.right) * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((-transform.up - transform.right) * Addedforce);
        //-----------------------------------
        //SHOOT UP---------------------------
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((transform.up + transform.right)* Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce((transform.up - transform.right)* Addedforce);
        //-----------------------------------
        //SHOOT SIDES------------------------
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * Addedforce);
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * Addedforce);
        //-----------------------------------
        SetTimer(timeTillShoot, () => Shoot());
    }

    private new void Move()
    {
        TimerStart();
        if (!pointSelected)
        {
            randomPositionX = UnityEngine.Random.Range(-4f, 4f);
            target = new Vector2(randomPositionX, transform.position.y);
            pointSelected = true;
        }
        if (!rotationReference.IntoTheVortex)
        {
            transform.eulerAngles += new Vector3(0, 0, rotationDegrees);
            transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
        }
    }

    private void Retrieve() {
        device.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, 0f);
        device.transform.rotation = Quaternion.identity;
        device.transform.SetParent(transform);
    }
}
