using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue_PlayerAni : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            setPlayerAni();
        }
    }
    void setPlayerAni()
    {
        PlayerState ps =  PlayerManager.Inst.getPlayerState();
        if (ps == PlayerState.walkright)
        {
            animator.SetBool("WalkRight", true);
        }
        else
        {
            animator.SetBool("WalkRight", false);
        }

        if (ps == PlayerState.walkleft)
        {
            animator.SetBool("WalkLeft", true);
        }
        else
        {
            animator.SetBool("WalkLeft", false);
        }
    }
}
