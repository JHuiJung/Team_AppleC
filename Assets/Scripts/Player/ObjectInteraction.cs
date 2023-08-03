using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionHowMany
{
    Once,
    permanent,
}

public enum InteractionFunction
{
    Move,
    etc,
}

public class ObjectInteraction : MonoBehaviour
{
    public InteractionHowMany howMany = InteractionHowMany.Once;
    public InteractionFunction function;

    public float x = 0f;
    public float y = 0f;
    float pushInteraction;

    private void Start()
    {
        // �ش� ������Ʈ�� �ڽ��ݶ��̴�2D�� ���� ��� ����
        if(this.GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pushInteraction = Input.GetAxisRaw("Interaction");
        if (pushInteraction > 0 )
        {
            if (function == InteractionFunction.Move)
            {
                PlayerManager.Inst.MovePlayer(x, y);
            }


            // Once �϶� �ѹ� ����ϰ� �� ������Ʈ ����
            if (howMany == InteractionHowMany.Once)
            {
                Destroy(gameObject);
            }
        }
    }
}
