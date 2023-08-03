using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue_After_ImageChange : MonoBehaviour
{
    public static Prologue_After_ImageChange Inst { get; private set; }
    private void Awake() => Inst = this;
    // Start is called before the first frame update
    public void ChangeImage(Sprite image)
    {
        this.GetComponent<Image>().sprite = image;
    }
}
