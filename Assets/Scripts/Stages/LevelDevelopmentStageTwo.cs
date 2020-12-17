using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDevelopmentStageTwo : LevelDevelopment
{

    public override IEnumerator RoutineLevel() {
        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Diamond", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2.4f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 1.4f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        yield return new WaitForSeconds(7f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y + 0), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Octahedron", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(10f);
        if (finish) StartCoroutine(Finish());
        yield return null;
    }

    public override void SaveScoreLost()
    {
        if (ScoreManager.TwoScore <= ScoreManager.GetScore()) ScoreManager.TwoScore = ScoreManager.GetScore();
        SaveData.SaveScore();
    }

    public override void SaveScoreAndUnlock()
    {
        if (ScoreManager.TwoScore <= ScoreManager.GetScore()) ScoreManager.TwoScore = ScoreManager.GetScore();     
        if (ScoreManager.GetUnlockedStage() == 1) ScoreManager.UnlockNewStage();
        SaveData.SaveScore();
    }
}
