using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    ScoreData DataLoaded;
    // Start is called before the first frame update
    void Start()
    {
        DataLoaded = SaveData.LoadScore();
        if (DataLoaded != null) ScoreManager.UpdateTheScore(DataLoaded);
    }
}
