using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prolouge_Box : MonoBehaviour
{
    float pushInteraction;
    public GameObject openObject;
    public GameObject closeObject;

    // Start is called before the first frame update

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        pushInteraction = Input.GetAxisRaw("Interaction");
        if (pushInteraction > 0)
        {
            PlayerManager.Inst.setPlayerState("idle");
            openObject.SetActive(true);
            Destroy(closeObject.GetComponent<PlayerMove>());
            Destroy(closeObject.GetComponent<CapsuleCollider2D>());
        }
    }

}
