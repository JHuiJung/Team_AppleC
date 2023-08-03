using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum whosay
{
    say_left,
    say_right,
    say_both,
}
[System.Serializable]
public class IntroDialogue
{
    public Sprite LeftImage;
    public Sprite RightImage;
    public whosay whosay;
    public float waitTime = 0f;
    public string name = " ";
    [TextArea]
    public string dialogue;
}

public class Prologue_Text : MonoBehaviour
{
    [SerializeField] private GameObject leftImage;
    [SerializeField] private GameObject rightImage;

    [SerializeField] private GameObject txt_panel;
    [SerializeField] private GameObject nextToggle;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;
    [SerializeField] private float textSpeed;
    [SerializeField] private GameObject nextObject;

    [SerializeField] private IntroDialogue[] dialogue;

    int cnt = 0;
    string playerName;
    bool isDialogue = false;
    bool skip = false;
    bool wait = false;

    void Start()
    {
        playerName = PlayerPrefs.GetString("playerName");
        StartDialogue();
    }
    private void StartDialogue()
    {
        Fill_Image(dialogue[cnt]);
        Fill_Name(dialogue[cnt]);
        StartCoroutine(TypingText(dialogue[cnt]));

    }
    void Fill_Name(IntroDialogue dialogue)
    {
        
        if (dialogue.name == "p")
        {
            txt_Name.text = "<b>" + playerName + "</b>";
        }
        else
        {
            txt_Name.text = "<b>" + dialogue.name + "</b>";
        }
        
    }
    void Fill_Image(IntroDialogue dialogue)
    {

        if(dialogue.LeftImage != null)
        {
            leftImage.GetComponent<Image>().sprite = dialogue.LeftImage;
        }
        else { leftImage.GetComponent<Image>().sprite = null; }

        if (dialogue.RightImage != null)
        {
            rightImage.GetComponent<Image>().sprite = dialogue.RightImage;
        }
        else { rightImage.GetComponent<Image>().sprite = null; }

        if(dialogue.whosay == whosay.say_left)
        {
            if (dialogue.RightImage != null)
            {
                Color a = rightImage.GetComponent<Image>().color;
                a.a = 1f;
                rightImage.GetComponent<Image>().color = a;
            }
            if (dialogue.LeftImage != null)
            {
                Color a = leftImage.GetComponent<Image>().color;
                a.a = 0.5f;
                leftImage.GetComponent<Image>().color = a;
            }

        }
        else if(dialogue.whosay == whosay.say_right)
        {
            if (dialogue.RightImage != null)
            {
                Color a = rightImage.GetComponent<Image>().color;
                a.a = 0.5f;
                rightImage.GetComponent<Image>().color = a;
            }
            if (dialogue.LeftImage != null)
            {
                Color a = leftImage.GetComponent<Image>().color;
                a.a = 1f;
                leftImage.GetComponent<Image>().color = a;
            }
        }
        else if(dialogue.whosay == whosay.say_both)
        {
            if (dialogue.RightImage != null)
            {
                Color a = rightImage.GetComponent<Image>().color;
                a.a = 1f;
                rightImage.GetComponent<Image>().color = a;
            }
            if (dialogue.LeftImage != null)
            {
                Color a = leftImage.GetComponent<Image>().color;
                a.a = 1f;
                leftImage.GetComponent<Image>().color = a;
            }
        }
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogue == false && wait == false)
        {
            NextDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Space)&& isDialogue == true && skip == false && wait == false)
        {
            skip = true;

        }

    }
    
    public void NextDialogue()
    {

        cnt++;
        nextToggle.gameObject.SetActive(false);
        if (cnt >= dialogue.Length)
        {
            if(nextObject != null)
            {
                nextObject.SetActive(true);
            }
            Destroy(gameObject);
        }
        else
        {
            Fill_Name(dialogue[cnt]);
            Fill_Image(dialogue[cnt]);
            StartCoroutine(TypingText(dialogue[cnt]));
        }
        


    }

    IEnumerator TypingText(IntroDialogue dialogue)
    {
        
        string txt = dialogue.dialogue;
        float waittime = dialogue.waitTime;
        if(waittime > 0)
        {
            wait = true;
            txt_Dialogue.text = " ";
            yield return new WaitForSeconds(waittime);
            wait = false;
        }
        
        isDialogue = true;
        for (int i = 0; i < txt.Length + 1; i++)
        {
            if (skip == true)
            {
                isDialogue = false;
                skip = false;
                txt_Dialogue.text = dialogue.dialogue;
                nextToggle.gameObject.SetActive(true);


                break;
            }
            txt_Dialogue.text = txt.Substring(0, i);
            yield return new WaitForSeconds(textSpeed);

        }
        nextToggle.gameObject.SetActive(true);
        isDialogue = false;
    }


    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator CloseAndOpenTxt(float time)
    {
        txt_panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(time);
        txt_panel.gameObject.SetActive(true);
    }

}