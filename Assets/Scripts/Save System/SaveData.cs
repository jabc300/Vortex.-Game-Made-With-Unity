using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveScore() {
        BinaryFormatter formatter = new BinaryFormatter();
        string machinePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(machinePath, "CerealGodGames\\Vortex");
        if (!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
        }
        string pathdata = Path.Combine(machinePath, "CerealGodGames\\Vortex\\JustNumbers.cereal");
        FileStream stream = new FileStream(pathdata, FileMode.Create);
        ScoreData scoreToSave = new ScoreData();
        formatter.Serialize(stream, scoreToSave);
        stream.Close();
    }

    public static ScoreData LoadScore() {
        string machinePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(machinePath, "CerealGodGames\\Vortex\\JustNumbers.cereal");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ScoreData scoreToLoad = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return scoreToLoad;
        } else
        {
            Debug.Log("Error, No Save File: " + path);
            return null;
        }
    }
}
