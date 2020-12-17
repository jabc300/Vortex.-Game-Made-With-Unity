
[System.Serializable]
public class ScoreData
{
    public int TotalScore { get; set; }
    public int OneScore { get; set; }
    public int TwoScore { get; set; }
    public int ThreeScore { get; set; }
    public int FourScore { get; set; }
    public int FiveScore { get; set; }
    public int SixScore { get; set; }
    public int SevenScore { get; set; }
    public int StCereal { get; set; }
    public bool UnLaser { get; set; }
    public bool UnShield { get; set; }
    public bool UnAnim0 { get; set; }
    public bool UnAnim1 { get; set; }
    public bool UnAnim2 { get; set; }
    public bool UnAnim3 { get; set; }
    public bool UnAnim4 { get; set; }
    public bool UnAnim5 { get; set; }

    public ScoreData() {
        OneScore = ScoreManager.OneScore;
        TwoScore = ScoreManager.TwoScore;
        ThreeScore = ScoreManager.ThreeScore;
        FourScore = ScoreManager.FourScore;
        FiveScore = ScoreManager.FiveScore;
        SixScore = ScoreManager.SixScore;
        SevenScore = ScoreManager.SevenScore;
        TotalScore = ScoreManager.TotalScore();
        StCereal = ScoreManager.GetUnlockedStage();
        UnLaser = ScoreManager.unlockedLaser;
        UnShield = ScoreManager.unlockedShield;
        UnAnim0 = ScoreManager.unlockedAnim0;
        UnAnim1 = ScoreManager.unlockedAnim1;
        UnAnim2 = ScoreManager.unlockedAnim2;
        UnAnim3 = ScoreManager.unlockedAnim3;
        UnAnim4 = ScoreManager.unlockedAnim4;
        UnAnim5 = ScoreManager.unlockedAnim5;
    }

}
