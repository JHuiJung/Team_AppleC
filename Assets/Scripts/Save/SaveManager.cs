using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public GameObject player;
    public int savepoint;

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        //
        PlayerPrefs.SetInt("savepoint", savepoint);
        PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.Save();
        
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("savepoint"))
        {
            savepoint = PlayerPrefs.GetInt("savepoint");
            float x = PlayerPrefs.GetFloat("PlayerPositionX");
            float y = PlayerPrefs.GetFloat("PlayerPositionY");

            player.transform.position = new Vector2(x, y);
        }
    }
    
    public void SaveRemove()
    {
        PlayerPrefs.DeleteAll();
    }

}
