using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    int fade = 0;
    private void Update()
    {
        Color a = this.GetComponent<Image>().color;

        if(fade == 0 && a.a >= 0)
        {
            a.a -= fadeSpeed * Time.deltaTime;
            this.GetComponent<Image>().color = a;
        }
        else if(fade == 1 && a.a <= 1)
        {
            a.a += fadeSpeed * Time.deltaTime;
            this.GetComponent<Image>().color = a;
        }
    }
    public void FadeIn()
    {
        fade = 1;

    }
    public void FadeOut()
    {
        fade = 0;
    }
    IEnumerator fadeOut()
    {
        Color a= this.GetComponent<Image>().color;
        while (a.a != 0) {
            a.a -= 0.01f;
            this.GetComponent<Image>().color = a;
            yield return new WaitForSeconds(0.01f);
        }

    }
    IEnumerator fadeIn()
    {
        Color a = this.GetComponent<Image>().color;
        while (a.a != 1)
        {
            a.a += 0.01f;
            this.GetComponent<Image>().color = a;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
