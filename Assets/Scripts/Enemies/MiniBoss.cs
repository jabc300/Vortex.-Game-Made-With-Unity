using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : EnemiesStats
{
    private const int movementLimit = 2;
    private const int signChange = -1;

    private const float randYRangeMin = 1f;
    private const float randYRangeMax = 2f;

    private const int originValue = 0;

    private const float offsetShootOneX = -0.4f;
    private const float offsetShootOneY = -0.5f;

    private const float offsetShootTwoX = 0.43f;
    private const float offsetShootTwoY = -0.5f;

    private const float diamondWait = 0.5f;
    private const float endSecondShootWait = 0.5f;

    private bool movingToTheZone;
    private bool startShooting;
    private bool notOut;
    private int selectedMovement;
    private int countMovement;
    private int nextRandom;

    // Start is called before the first frame update
    void Start()
    {
        rotationReference = GetComponent<RotateAroundVortex>();
        SetTimer(timeTillShoot, () => StartCoroutine(ShootRoutine()));
        notOut = true;
        countMovement = 0;
        selectedMovement = 0;       
        Addedforce = 425;
        timeTillShoot = 0.25f;
        randomPositionX = 6;
        startShooting = false;
        movingToTheZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotationReference.IntoTheVortex) Move();
        if (rotationReference.IntoTheVortex) Shoot();
    }
    private new void Move()
    {
        correctedSpeed = speed * Time.deltaTime;
        if(startShooting)Shoot();
        if(selectedMovement == 0)MoveToCenter();
        else if(selectedMovement == 1)MoveLeftRight();
    }

    private void MoveLeftRight() {
        if (countMovement < movementLimit)
        {
            if (!movingToTheZone)
            {
                randomPositionX = signChange * randomPositionX;
                randomPositionY = Random.Range(randYRangeMin, randYRangeMax);
                target = new Vector2(randomPositionX, randomPositionY);
                movingToTheZone = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
                if (transform.position.x == target.x && transform.position.y == target.y)
                {
                    movingToTheZone = false;
                    startShooting = true;
                    countMovement++;
                }
            }
        }
        else {
            
            nextRandom = Random.Range(-1, 1);
            if (nextRandom == 0) randomPositionX = signChange * randomPositionX;
            countMovement = 0;
            startShooting = false;
            selectedMovement = 0;
        }
    }

    private void MoveToCenter()
    {
        target = new Vector2(originValue, originValue);
        transform.position = Vector2.MoveTowards(transform.position, target, correctedSpeed);
        if (transform.position.x == target.x && transform.position.y == target.y && notOut)
        {
            StartCoroutine(Shoot2());
            notOut = false;
        }
    }

    private new void Shoot() {       
        TimerStart();
    }
    private IEnumerator ShootRoutine()
    {
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", new Vector2(transform.position.x + offsetShootOneX, transform.position.y + offsetShootOneY), transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        yield return new WaitForSeconds(0.1f);
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", new Vector2(transform.position.x + offsetShootTwoX, transform.position.y + offsetShootTwoY), transform.rotation);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * Addedforce);
        SetTimer(timeTillShoot, () => StartCoroutine(ShootRoutine()));
        yield return null;
    }

    private IEnumerator Shoot2() {
        ObjectsPool.UsePoolObject("Diamond", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(diamondWait);
        ObjectsPool.UsePoolObject("Diamond", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(endSecondShootWait);
        selectedMovement = 1;
        notOut = true;
        yield return null;
    }
}
