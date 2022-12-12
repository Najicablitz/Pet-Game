using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void OnSave(CatParameters catParameters, FeedArea_Script feedArea, LitterArea_Script litterArea, Time_Manager tm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneData data = new SceneData(catParameters, feedArea, litterArea, tm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SceneData OnLoad()
    {
        string path = Application.persistentDataPath + "/scene.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
