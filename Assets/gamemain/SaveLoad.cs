using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    PlayerData Data;

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public float HP;
        public int Lvl;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Save();
            Debug.Log("is ok");       
        }
        if (Input.GetKeyDown(KeyCode.L))
            Load();
    }
    public void Save()
    {
        playcontrol player = GetComponent<playcontrol>();
        int HP = player.hp;
        PlayerPrefs.SetString("name", Data.name);
        PlayerPrefs.SetFloat("HP", HP);
        PlayerPrefs.SetInt("Lvl", Data.Lvl);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        Data.name = PlayerPrefs.GetString("name");
        Data.HP = PlayerPrefs.GetFloat("HP");
        Data.Lvl = PlayerPrefs.GetInt("Lvl");
    }
}
