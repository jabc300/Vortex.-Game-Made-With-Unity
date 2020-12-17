using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life;
    public float MaxLife;
    public int givenScore;
    public bool activateScore;

    private RotateAroundVortex rotationReference;
    private void Start()
    {
        rotationReference = GetComponent<RotateAroundVortex>();
        EventsManager.eventsManager.OnGameFinish += createEndExplosion;
    }

    private void OnEnable()
    {        
        life = MaxLife;
    }

    public void createExplosion()
    {        
        life = 0;
        if (activateScore) addDeadEnemyandUpdateScore();
        
        if (gameObject.CompareTag("RotatoryEnemy"))
        {
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.tag = "Enemy";
        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        rotationReference.IntoTheVortex = false;
        if(ScoreManager.unlockedShield)ObjectsPool.UsePoolObject("ShieldItem", transform.position, Quaternion.identity);
        ObjectsPool.UsePoolObject("Explosion", gameObject.transform.position, Quaternion.identity);
        ObjectsPool.returnToQueque(gameObject);
    }

    public void createExplosionForNoQueue()
    {
        addDeadEnemyandUpdateScore();
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        ObjectsPool.UsePoolObject("Explosion", gameObject.transform.position, Quaternion.identity);
        transform.SetParent(null);
        gameObject.transform.position = new Vector3(100000, 100000, 0f);
    }

    public void createEndExplosion() {
        if (gameObject.activeSelf && (CompareTag("Enemy")|| CompareTag("RotatoryEnemy")))
        {
            ObjectsPool.UsePoolObject("Explosion", gameObject.transform.position, Quaternion.identity);
            ObjectsPool.returnToQueque(gameObject);
        }
    }

    private void OnDisable()
    {
        life = MaxLife;
    }

    private void OnDestroy()
    {
        EventsManager.eventsManager.OnGameFinish -= createEndExplosion;
    }

    private void addDeadEnemyandUpdateScore() {
        ScoreManager.TheDeadCounter();
        ScoreManager.Score(givenScore);
    }
}
