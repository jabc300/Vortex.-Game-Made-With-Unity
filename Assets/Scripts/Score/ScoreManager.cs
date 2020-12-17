
public class ScoreManager
{
    private static int theScore;
    private static int finalScore;
    private static int theExtraScore;


    #region GetSetInt
    public static int DeadCounter { get; set; } = 0;
    public static int ScoreMultiplier { get; set; }
    public static int OneScore { get; set; } 
    public static int TwoScore { get; set; }
    public static int ThreeScore { get; set; } 
    public static int FourScore { get; set; }
    public static int FiveScore { get; set; } 
    public static int SixScore { get; set; } 
    public static int SevenScore { get; set; }
    public static int AnimSelected { get; set; }
    #endregion

    #region GetSetBool
    public static bool unlockedLaser { get; set; }
    public static bool unlockedShield { get; set; }
    public static bool unlockedAnim0 { get; set; }
    public static bool unlockedAnim1 { get; set; }
    public static bool unlockedAnim2 { get; set; }
    public static bool unlockedAnim3 { get; set; }
    public static bool unlockedAnim4 { get; set; }
    public static bool unlockedAnim5 { get; set; }
    #endregion

    private static int SavedStage { get; set; }
    private static int unlockedStage { get; set; }

    public static void TheDeadCounter() {
        DeadCounter++;
    }

    public static void GiveExtraScore(int extraScore) {

        theExtraScore = extraScore;
    }

    public static void ResetExtraScore() {
        theExtraScore = 0;
    }

    public static int Score(int givenScore)
    {       
        if (DeadCounter == 10)
        {
            ScoreMultiplier++;
            DeadCounter = 0;
        }
        theScore += ScoreMultiplier * (givenScore + theExtraScore);
        EventsManager.eventsManager.ChangeTheScore();
        return theScore;
    }

    public static int GetDeadCounter() {
        return DeadCounter;
    }

    public static void ResetScoreMultiplierAndDeadCounter() {
        ScoreMultiplier = 1;
        DeadCounter = 0;
    }

    public static int GetScore() {
        return theScore;
    }

    public static void ResetScore() {
        theScore = 0;
    }

    public static int TotalScore() {
        finalScore = OneScore + TwoScore + ThreeScore + FourScore + FiveScore + SixScore + SevenScore;
        return finalScore;
    }

    public static void UpdateTheScore(ScoreData scoreToUpdate) {
        OneScore = scoreToUpdate.OneScore;
        TwoScore = scoreToUpdate.TwoScore;
        ThreeScore = scoreToUpdate.ThreeScore;
        FourScore = scoreToUpdate.FourScore;
        FiveScore = scoreToUpdate.FiveScore;
        SixScore = scoreToUpdate.SixScore;
        SevenScore = scoreToUpdate.SevenScore;
        scoreToUpdate.TotalScore = TotalScore();
        unlockedStage = scoreToUpdate.StCereal;
        unlockedLaser = scoreToUpdate.UnLaser;
        unlockedShield = scoreToUpdate.UnShield;
        unlockedAnim0 = scoreToUpdate.UnAnim0;
        unlockedAnim1 = scoreToUpdate.UnAnim1;
        unlockedAnim2 = scoreToUpdate.UnAnim2;
        unlockedAnim3 = scoreToUpdate.UnAnim3;
        unlockedAnim4 = scoreToUpdate.UnAnim4;
        unlockedAnim5 = scoreToUpdate.UnAnim5;
    }

    public static void SaveSceneValue(int value) {
        SavedStage = value;
    }

    public static int GetSavedStage() {
        return SavedStage;
    }

    public static void UnlockNewStage() {
        unlockedStage++;
    }

    public static int GetUnlockedStage()
    {
        return unlockedStage;
    }

}
