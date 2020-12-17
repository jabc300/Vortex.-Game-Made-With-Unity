using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtThePlayer : MonoBehaviour
{
    public float AddedForce;
    private bool cycle;

    public GameObject Ship;
    private GameObject instantiatedBullet;
    public GameObject BossShip;
    private BossShoot bossRef;
    private Life lifeComponent;
   
    // Update is called once per frame

    void Start()
    {
        bossRef = BossShip.GetComponent<BossShoot>();
        lifeComponent = GetComponent<Life>();
        cycle = true;
    }
    void Update()
    {
        if (!bossRef.animationStart)
        {
            transform.up = transform.position - Ship.transform.position;
            if (cycle && !bossRef.deadBoss)
            {
                StartCoroutine(TimeToShoot());
                cycle = false;
            }
            else if (bossRef.deadBoss)
            {
                lifeComponent.createExplosionForNoQueue();
                gameObject.SetActive(false);
            }
        }
    }
    void Shoot() {
        AudioManager.inst.Play("ShootEnemy");
        instantiatedBullet = ObjectsPool.UsePoolObject("EnemyBullet", transform.position, Quaternion.identity);
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(-1*transform.up * AddedForce);
    }

    private IEnumerator TimeToShoot() {
        yield return new WaitForSeconds(2);
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        yield return new WaitForSeconds(0.2f);
        Shoot();
        cycle = true;
        yield return null;
    }

}
