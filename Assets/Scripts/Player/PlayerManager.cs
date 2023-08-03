using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public GameObject player;
    PlayerMove playerMove;
    StaminaBar staminaBar;
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        staminaBar = player.GetComponent<StaminaBar>();
    }
    
    public int getPlayerSpeed()
    {
        return playerMove.getPlayerSpeed();
    }
    
    public void MovePlayer(float x, float y)
    {
        player.transform.position = new Vector3(x, y, 1);
    }

    public float getStemina()
    {
        return playerMove.getStamina();
    }

    public void setPlayerState(string playerState)
    {
        playerMove.setPlayerState(playerState);
    }
    public PlayerState getPlayerState()
    {
        return (PlayerState)playerMove.getPlayerState();
    }

    public void StaminaBarOff()
    {
        staminaBar.StaminaBarOff();
    }
    public void StaminaBarOn()
    {
        staminaBar.StaminaBarOn();
    }
    public bool isStaminaBarActive()
    {
        return staminaBar.isStaminaBarActive();
    }

}
