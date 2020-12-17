using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRepositoryBoss : ObjectsPool
{
    public int EnemyBulletsQuantity;
    public int BulletVortexQuantity;
    public int TriangleEnemyQuantity;
    public int DiamondEnemyQuantity;
    public int MiniBossQuantity;
    public int VortexQuantity;
    public int ExplosionQuantity;
    public int HealthItemQuantity;
    public int ShieldItemQuantity;

    public GameObject EnemyBullets;
    public GameObject BulletVortex;
    public GameObject TriangleEnemy;
    public GameObject DiamondEnemy;
    public GameObject MiniBossEnemy;
    public GameObject Vortex;
    public GameObject Explosion;
    public GameObject HealthItem;
    public GameObject ShieldItem;

    private Life EnemyComponent;
    // Start is called before the first frame update
    void Start()
    {
        pool.Clear();
        CreateInstance(EnemyBullets.GetComponent<DictionaryKey>().TheKey, EnemyBullets, EnemyBulletsQuantity);
        CreateInstance(BulletVortex.GetComponent<DictionaryKey>().TheKey, BulletVortex, BulletVortexQuantity);
        EnemyComponent = TriangleEnemy.GetComponent<Life>();
        EnemyComponent.activateScore = false;
        CreateInstance(TriangleEnemy.GetComponent<DictionaryKey>().TheKey, TriangleEnemy, TriangleEnemyQuantity);
        EnemyComponent = DiamondEnemy.GetComponent<Life>();
        EnemyComponent.activateScore = false;
        CreateInstance(DiamondEnemy.GetComponent<DictionaryKey>().TheKey, DiamondEnemy, DiamondEnemyQuantity);
        CreateInstance(MiniBossEnemy.GetComponent<DictionaryKey>().TheKey, MiniBossEnemy, MiniBossQuantity);
        CreateInstance(Vortex.GetComponent<DictionaryKey>().TheKey, Vortex, VortexQuantity);
        CreateInstance(Explosion.GetComponent<DictionaryKey>().TheKey, Explosion, ExplosionQuantity);
        CreateInstance(HealthItem.GetComponent<DictionaryKey>().TheKey, HealthItem, HealthItemQuantity);
        CreateInstance(ShieldItem.GetComponent<DictionaryKey>().TheKey, ShieldItem, ShieldItemQuantity);
    }

}
