using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRepository : ObjectsPool
{
    public int EnemyBulletsQuantity;
    public int BulletVortexQuantity;
    public int TriangleEnemyQuantity;
    public int DiamondEnemyQuantity;
    public int OctahedronEnemyQuantity;
    public int OctagonEnemyQuantity;
    public int VortexQuantity;
    public int ExplosionQuantity;
    public int HealthItemQuantity;
    public int ShieldItemQuantity;

    public GameObject EnemyBullets;
    public GameObject BulletVortex;
    public GameObject TriangleEnemy;
    public GameObject DiamondEnemy;
    public GameObject OctahedronEnemy;
    public GameObject OctagonEnemy;
    public GameObject Vortex;
    public GameObject Explosion;
    public GameObject HealthItem;
    public GameObject ShieldItem;
    // Start is called before the first frame update
    void Start()
    {
        pool.Clear();
        CreateInstance(EnemyBullets.GetComponent<DictionaryKey>().TheKey,EnemyBullets, EnemyBulletsQuantity);
        CreateInstance(BulletVortex.GetComponent<DictionaryKey>().TheKey, BulletVortex, BulletVortexQuantity);
        CreateInstance(TriangleEnemy.GetComponent<DictionaryKey>().TheKey, TriangleEnemy, TriangleEnemyQuantity);
        CreateInstance(DiamondEnemy.GetComponent<DictionaryKey>().TheKey, DiamondEnemy, DiamondEnemyQuantity);
        CreateInstance(OctahedronEnemy.GetComponent<DictionaryKey>().TheKey, OctahedronEnemy, OctahedronEnemyQuantity);
        CreateInstance(OctagonEnemy.GetComponent<DictionaryKey>().TheKey, OctagonEnemy, OctagonEnemyQuantity);
        CreateInstance(Vortex.GetComponent<DictionaryKey>().TheKey, Vortex, VortexQuantity);
        CreateInstance(Explosion.GetComponent<DictionaryKey>().TheKey, Explosion, ExplosionQuantity);
        CreateInstance(HealthItem.GetComponent<DictionaryKey>().TheKey, HealthItem, HealthItemQuantity);
        CreateInstance(ShieldItem.GetComponent<DictionaryKey>().TheKey, ShieldItem, ShieldItemQuantity);

    }
}
