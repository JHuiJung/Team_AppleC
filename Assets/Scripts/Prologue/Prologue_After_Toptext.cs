using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue_After_Toptext : MonoBehaviour
{
    public GameObject TopText;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if(TopText != null)
        {
            if(PlayerManager.Inst.getPlayerState() != PlayerState.idle)
            {
                Destroy(TopText);
            }
        }

    }
}
