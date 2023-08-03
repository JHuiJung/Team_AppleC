using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] GameObject staminaBar;
    float staminaBarSizex = 2.5f;
    float staminaBarSizey = 0.25f;
    float getStamina;

    void Start()
    {
        staminaBarSizex = staminaBar.transform.localScale.x;
        staminaBarSizey = staminaBar.transform.localScale.y;

    }
    void Update()
    {
        getStamina = PlayerManager.Inst.getStemina();
        staminaBar.GetComponent<Transform>().localScale = new Vector3((staminaBarSizex *(getStamina / 100)),staminaBarSizey, 0f);
        staminaBar.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f-(getStamina/100));
    }
 
    public void StaminaBarOff()
    {
        staminaBar.gameObject.SetActive(false);
    }
    public void StaminaBarOn()
    {
        staminaBar.gameObject.SetActive(true);
    }
    public bool isStaminaBarActive()
    {
        return staminaBar.gameObject.activeSelf;
    }
}
