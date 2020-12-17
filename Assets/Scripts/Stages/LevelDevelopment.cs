using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDevelopment : MonoBehaviour
{
    public GameObject Ship;
    public bool finish;
    protected bool AnimationOn;
    // Start is called before the first frame update
    void Start()
    {
        finish = true;
        AnimationOn = false;
        EventsManager.eventsManager.OnDeadPlayer += Lost;
        StartCoroutine(RoutineLevel());
    }

    private void OnDestroy()
    {
        EventsManager.eventsManager.OnDeadPlayer -= Lost;
    }

    public void Lost() {
        finish = false;
        SaveScoreLost();
    }

    public IEnumerator Finish() {
        Ship.GetComponent<BoxCollider2D>().enabled = false;
        if(finish) EventsManager.eventsManager.ActivateStageComplete();
        yield return new WaitForSeconds(6);
        if (finish)
        {
            SaveScoreAndUnlock();
            ScoreManager.ResetScore();
            ScoreManager.ResetScoreMultiplierAndDeadCounter();
            if (AnimationOn)SceneManager.LoadScene("AnimationTransition", LoadSceneMode.Single);
            else SceneManager.LoadScene("Selection", LoadSceneMode.Single);
        }
        yield return null;
    }

    public virtual IEnumerator RoutineLevel() {

        yield return new WaitForSeconds(2);
        ObjectsPool.UsePoolObject("Triangle", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2.5f), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 3.2f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2.8f), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.3f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.8f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 1f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y - 1.3f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.3f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 1f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y - 2), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y - 2), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y - 1.3f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 3.3f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y - 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 3.4f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 3), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 2.6f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 2.2f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 1.8f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y - 1.4f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y + 0.6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y + 0.2f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y - 0.2f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
        ObjectsPool.UsePoolObject("Triangle", new Vector2(-transform.position.x, transform.position.y - 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 0.8f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1.2f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1.3f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1.8f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 2.3f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y + 2.3f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(-transform.position.x, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        ObjectsPool.UsePoolObject("Diamond", new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(10f);
        if(finish) StartCoroutine(Finish());
        yield return null;
    }

    public virtual void SaveScoreLost()
    {
        if (ScoreManager.OneScore <= ScoreManager.GetScore()) ScoreManager.OneScore = ScoreManager.GetScore();
        SaveData.SaveScore();
    }

    public virtual void SaveScoreAndUnlock()
    {
        if (ScoreManager.OneScore <= ScoreManager.GetScore()) ScoreManager.OneScore = ScoreManager.GetScore();
        if (ScoreManager.GetUnlockedStage() == 0) ScoreManager.UnlockNewStage();
        if (!ScoreManager.unlockedLaser) ScoreManager.unlockedLaser = true;
        if (!ScoreManager.unlockedAnim1) {
            ScoreManager.unlockedAnim1 = true;
            ScoreManager.AnimSelected = 1;
            AnimationOn = true;
        }
        SaveData.SaveScore();
    }
}
