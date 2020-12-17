using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataUpload : MonoBehaviour
{
    TextAsset textVortex;
    string[] dataInfo;
    public List<string> dataIndividual;
    public static List<TextData> ListTextData;
    TextData data;


    // Start is called before the first frame update
    void Start()
    {
        ListTextData = new List<TextData>();
        textVortex = Resources.Load<TextAsset>("TextVortex");
        dataInfo = textVortex.text.Split('\n');

        for (int i = 1; i < dataInfo.Length; i++)
        {
            dataIndividual = dataInfo[i].Split(',').ToList();
            data = new TextData();
            int.TryParse(dataIndividual[0], out data.Id);
            dataIndividual.RemoveAt(0);
            data.Paragraphs = dataIndividual.ToArray();
            ListTextData.Add(data);
        }
    }
}
