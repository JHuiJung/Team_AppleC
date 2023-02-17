using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] int playerSpeed = 5;


    void Update()
    {
        playerMoove();
    }
    
    public int getPlayerSpeed()
    {
        return playerSpeed;
    }

    public void setPlayerSpeed(int playerSpeed)
    {
        this.playerSpeed = playerSpeed;
    }

    void playerMoove()
    {
        // 오른쪽 방향키 누를때
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
        }

        // 왼쪽 방향키 누를때
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));
        }
    }
}
