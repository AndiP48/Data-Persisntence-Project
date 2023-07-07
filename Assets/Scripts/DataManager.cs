using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    static public DataManager Intance;

    public string user;
    public string newUser;
    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        if (Intance != null)
        {
            Destroy(gameObject);
        }

        Intance = this;

        DontDestroyOnLoad(this);

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // get json
    [System.Serializable]
    class User
    {
        public string user;
        public int score;
    }

    public void SaveData()
    {
        User data = new User();

        data.user = user;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            User data = JsonUtility.FromJson<User>(json);

            user = data.user;
            score = data.score;
        }
    }
}
