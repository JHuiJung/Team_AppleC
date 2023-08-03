using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Prologue_scene7Pm : MonoBehaviour
{
    public GameObject player;
    public GameObject openObj;
    public GameObject pImage;
    public GameObject fade;
    public Sprite image;
    Animator animator;
    int playerSpeed = 5;
    Transform playerTransform;
    public Vector3 stopPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x > stopPosition.x)
        {
            animator.SetBool("WalkRight", false);
            fade.GetComponent<FadeInOut>().FadeIn();
            StartCoroutine(fadeout());
            
            
        }
        else
        {
            animator.SetBool("WalkRight",true);
            player.transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));
        }
        
    }
    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(2f);
        pImage.GetComponent<Prologue_After_ImageChange>().ChangeImage(image);
        fade.GetComponent<FadeInOut>().FadeOut();
        yield return new WaitForSeconds(2f);
        openObj.SetActive(true);
        Destroy(gameObject);
    }
}
