using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDevelopmentStageFour : LevelDevelopment
{

    public override IEnumerator RoutineLevel() {
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x+1, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(12);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.4f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.4f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.4f), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(6);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.6f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(7);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.6f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(4);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 2.8f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x + 1, transform.position.y + 2.4f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x - 1, transform.position.y + 2f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.6f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 1.2f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 0.8f), Quaternion.identity);
        yield return new WaitForSeconds(4);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2.4f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(10);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 1f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 0.6f), Quaternion.identity);
        yield return new WaitForSeconds(10);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y +3.3f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 2.2f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 1.6f), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 1f), Quaternion.identity);
        yield return new WaitForSeconds(15f);
        if (finish) StartCoroutine(Finish());
        yield return null;
    }

    public override void SaveScoreLost()
    {
        if (ScoreManager.FourScore <= ScoreManager.GetScore()) ScoreManager.FourScore = ScoreManager.GetScore();
        SaveData.SaveScore();
    }

    public override void SaveScoreAndUnlock()
    {
        if (ScoreManager.FourScore <= ScoreManager.GetScore()) ScoreManager.FourScore = ScoreManager.GetScore();        
        if (ScoreManager.GetUnlockedStage() == 3) ScoreManager.UnlockNewStage();
        if (!ScoreManager.unlockedShield) ScoreManager.unlockedShield = true;
        if (!ScoreManager.unlockedAnim3)
        {
            ScoreManager.unlockedAnim3 = true;
            ScoreManager.AnimSelected = 3;
            AnimationOn = true;
        }
        SaveData.SaveScore();
    }
}
