using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDevelopmentBoss : LevelDevelopment
{
    public GameObject BossShip;
    private BossShoot bossCode;
    private GameObject miniBoss;
    // Update is called once per frame
    private void Awake()
    {
        bossCode = BossShip.GetComponent<BossShoot>();
    }

    public override IEnumerator RoutineLevel()
    {

        while (!bossCode.deadBoss)
        {
            yield return new WaitForSeconds(1);
            if(!bossCode.animationStart)
            {
                yield return new WaitForSeconds(3);
                ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 1f), Quaternion.identity);
                ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y - 1.3f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 1.6f), Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
        }
        miniBoss = bossCode.miniBoss;
        while (miniBoss.activeSelf) { yield return new WaitForSeconds(2); }
        if(finish) StartCoroutine(Finish());
        yield return null;
    }

    public override void SaveScoreLost()
    {
        if (ScoreManager.SevenScore <= ScoreManager.GetScore()) ScoreManager.SevenScore = ScoreManager.GetScore();
        SaveData.SaveScore();
    }

    public override void SaveScoreAndUnlock()
    {
        if (ScoreManager.SevenScore <= ScoreManager.GetScore()) ScoreManager.SevenScore = ScoreManager.GetScore();
        if (!ScoreManager.unlockedAnim5)
        {
            ScoreManager.unlockedAnim5 = true;
            ScoreManager.AnimSelected = 5;
            AnimationOn = true;
        }
        SaveData.SaveScore();
    }
}
