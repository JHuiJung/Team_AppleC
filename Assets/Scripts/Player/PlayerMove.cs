using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkTonic.MasterAudio;
public enum PlayerState
{
    idle,
    walkright,
    walkleft,
    runright,
    runleft,
    exhausted,
}
public class PlayerMove : MonoBehaviour
{
    [SerializeField] int playerSpeed = 5;
    [SerializeField] int walkSpeed = 5;
    [SerializeField] int runSpeed = 9;
    [SerializeField] float stamina = 100f;
    [SerializeField] float decreaseStamina = 60f;
    [SerializeField] float increaseStamina = 30f;
    float hAxis;
    float run;

    PlayerState playerState = PlayerState.idle;

    void Update()
    {
        playerMoove();
        checkStamina();
    }

    public int getPlayerSpeed()
    {
        return playerSpeed;
    }
    void setPlayerSpeed(int PlayerSpeed)
    {
        this.playerSpeed = PlayerSpeed;
    }

    public void setWalkSpeed(int walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }
    public int getWalkSpeed()
    {
        return this.walkSpeed;
    }

    public void setRunSpeed(int runSpeed)
    {
        this.runSpeed = runSpeed;
    }
    public int getRunSpeed()
    {
        return this.runSpeed;
    }

    public void setPlayerState(string playerState = "idle")
    {
        if (playerState == "idle")
        {
            this.playerState = PlayerState.idle;
        }
        else if (playerState == "walkright")
        {
            this.playerState = PlayerState.walkright;
        }
        else if (playerState == "walkleft")
        {
            this.playerState = PlayerState.walkleft;
        }
        else if (playerState == "runright")
        {
            this.playerState = PlayerState.runright;
        }
        else if (playerState == "runleft")
        {
            this.playerState = PlayerState.runleft;
        }
        else if (playerState == "exhausted")
        {
            this.playerState = PlayerState.exhausted;
        }

    }
    public float getStamina()
    {
        return stamina;
    }
    public PlayerState getPlayerState()
    {
        return this.playerState;
    }

    void playerMoove()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        run = Input.GetAxisRaw("Run");

        //지친 상태가 아니여야 움직일 수 있음
        if (playerState != PlayerState.exhausted)
        {
            if (hAxis > 0)
            {
                if (run > 0)
                {
                    setPlayerState("runright");
                    setPlayerSpeed(runSpeed);
                }
                else
                {
                    setPlayerState("walkright");
                    setPlayerSpeed(walkSpeed);
                }


                transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
            }
            else if (hAxis < 0)
            {
                if (run > 0)
                {
                    setPlayerState("runleft");
                    setPlayerSpeed(runSpeed);
                }
                else
                {
                    setPlayerState("walkleft");
                    setPlayerSpeed(walkSpeed);
                }

                transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
            }
            else
            {
                setPlayerSpeed(walkSpeed);
                setPlayerState("idle");
            }
        }



    }
    void checkStamina()
    {
        if (playerState == PlayerState.runright || playerState == PlayerState.runleft)
        {
            if (!PlayerManager.Inst.isStaminaBarActive())
            {
                PlayerManager.Inst.StaminaBarOn();
            }
            if (stamina > 0)
            {
                stamina -= decreaseStamina * Time.deltaTime;
                if (stamina < 45) { MasterAudio.PlaySound3DAtTransform("GirlBreathing_1.5", transform); }
            }
            else if (stamina <= 0)
            {
                stamina = 0;
                setPlayerState("exhausted");
            }
        }
        else
        {
            if (stamina < 100) { stamina += increaseStamina * Time.deltaTime; }
            else if (stamina >= 100)
            {
                stamina = 100f;
                if (PlayerManager.Inst.isStaminaBarActive())
                {
                    PlayerManager.Inst.StaminaBarOff();
                }
                if (playerState == PlayerState.exhausted)
                {
                    setPlayerState("idle");
                }

            }
        }
    }
}
    
