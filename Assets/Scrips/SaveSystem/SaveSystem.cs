using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveHighscore (HighScore highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Score.Testing";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        ScoreData data = new ScoreData(highScore);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static ScoreData LoadHighscore()
    {
        string path = Application.persistentDataPath + "/Score.Testing";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();
            
            return data;
            
        } else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}