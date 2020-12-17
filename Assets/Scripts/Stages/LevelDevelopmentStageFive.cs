using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDevelopmentStageFive : LevelDevelopment
{
    public override IEnumerator RoutineLevel()
    {       
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 0.6f), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(7);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(3);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(6);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(4);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x+1, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(10);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y+2), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x+1, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(7);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x+1, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(7);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x-1, transform.position.y + 1.6f), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y+3.4f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x-1, transform.position.y + 0.6f), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x+1, transform.position.y+ 3f), Quaternion.identity);
        yield return new WaitForSeconds(5);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x-1, transform.position.y + 1f), Quaternion.identity);
        yield return new WaitForSeconds(17);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(transform.position.x - 1, transform.position.y + 2.6f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octagon", new Vector2(-transform.position.x + 1, transform.position.y + 1.4f), Quaternion.identity);
        yield return new WaitForSeconds(17);
        if (finish) StartCoroutine(Finish());
        yield return null;
    }

    public override void SaveScoreLost()
    {
        if (ScoreManager.FiveScore <= ScoreManager.GetScore()) ScoreManager.FiveScore = ScoreManager.GetScore();
        SaveData.SaveScore();
    }

    public override void SaveScoreAndUnlock()
    {
        if (ScoreManager.FiveScore <= ScoreManager.GetScore()) ScoreManager.FiveScore = ScoreManager.GetScore();      
        if (ScoreManager.GetUnlockedStage() == 4) ScoreManager.UnlockNewStage();       
        SaveData.SaveScore();
    }
}
