using DG.Tweening.Plugins.Core.PathCore;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public void Initialize()
    {
        if (!Directory.Exists(Application.persistentDataPath + Settings.savePath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + Settings.savePath);
        }
    }

    public string GetJsonFromData<T>(T data)
    {
        string json = JsonUtility.ToJson(data, true);

        return json;
    }

    public T GetDataFromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public void Save(string jsonData, string key)
    {
        string path = Application.persistentDataPath + Settings.savePath;

        File.WriteAllText(path + key, jsonData);
    }

    public T Load<T>(string key)
    {
        string path = Application.persistentDataPath + Settings.savePath;

        string jsonData = File.ReadAllText(path + key);

        T data = default;

        if (IsSaveExist(key))
        {
            data = GetDataFromJson<T>(jsonData);
        }

        return data;
    }

    private bool IsSaveExist(string key)
    {
        string path = Application.persistentDataPath + Settings.savePath;

        return File.Exists(path + key);
    }
}