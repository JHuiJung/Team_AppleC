using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavepointInteraction : MonoBehaviour
{

    public int savepoint;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("savepoint") >= savepoint)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            SaveManager.Inst.savepoint += 1;
            SaveManager.Inst.Save();
            this.gameObject.SetActive(false);
        }
    }
}
