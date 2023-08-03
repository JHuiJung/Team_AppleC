using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public GameObject nextGameObject;
    public GameObject ImgGameObject;
    public Sprite blank;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NameSet()
    {
        PlayerPrefs.SetString("playerName",playerNameInput.text);
        Debug.Log(PlayerPrefs.GetString("playerName"));
        nextGameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        ImgGameObject.GetComponent<Image>().sprite = blank;
    }
}
