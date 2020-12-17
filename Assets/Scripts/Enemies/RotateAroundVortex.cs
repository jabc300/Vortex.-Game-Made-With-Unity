using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundVortex : MonoBehaviour
{

    public GameObject EnemyExplosion;
    public bool IntoTheVortex;
    public bool ActivateRotation;
    public float reducedLife;
    public float absorbingTime;
    private float distanceX;
    private float distanceY;
    private float magnitud;
    private float magnitudeReduction;
    

    private const float magnitudToDestroy = 0.008f;
    private const int limitToRotate = 0;

    private Transform VortexPosition;
    private Vector3 reductionDownLeft;
    private Vector3 reductionDownRight;
    private Vector3 reductionUpRight;
    private Vector3 reductionUpLeft;

    private float correctedSpeed;
    private Vector3 direction;
    private Life lifeComponent;
    private Vortex vortexRef;
    // Start is called before the first frame update

    private void OnEnable()
    {
        IntoTheVortex = false;
    }

    private void OnDisable()
    {
        if(vortexRef)vortexRef.OnVortexCatch -= lifeComponent.createExplosion;
        IntoTheVortex = false;
    }

    private void Start()
    {
        lifeComponent = GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {     
        rotateAround();
    }

    void rotateAround() {
        if (IntoTheVortex)
        {
            direction = magnitud * Vector3.Normalize(transform.position - VortexPosition.position) + VortexPosition.position;
            transform.position = direction;
            transform.RotateAround(VortexPosition.position, Vector3.back, 1);         
            magnitud -= (1 / absorbingTime) * Time.deltaTime;
            if (magnitud <= magnitudToDestroy)
            {
                lifeComponent.createExplosion();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vortex") && gameObject.CompareTag("Enemy") && (!transform.Find("AntigravitatoryDevice"))) {             
            gameObject.tag = "RotatoryEnemy";
            vortexRef = collision.GetComponent<Vortex>();
            vortexRef.OnVortexCatch += lifeComponent.createExplosion;
            VortexPosition = collision.gameObject.transform;
            transform.SetParent(VortexPosition);
            magnitud = Vector3.Magnitude(transform.position - VortexPosition.position);                       
            if (lifeComponent.life > reducedLife) lifeComponent.life = reducedLife;
            IntoTheVortex = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("ReturnedBullet") && GetComponent<DictionaryKey>().TheKey != "miniBoss") {
            collision.gameObject.layer = LayerMask.NameToLayer("Bullet");
            lifeComponent.createExplosion();
            ObjectsPool.returnToQueque(collision.gameObject);           
        }else if(collision.gameObject.layer == LayerMask.NameToLayer("ReturnedBullet") && GetComponent<DictionaryKey>().TheKey == "miniBoss") ObjectsPool.returnToQueque(collision.gameObject);
    }
}
