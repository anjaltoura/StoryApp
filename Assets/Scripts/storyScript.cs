using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyScript : MonoBehaviour
{
    public Text mainText;
    public Text lastText; 
    public string displayText = "";
    public Image image;
    public Sprite altImage;
    public GameObject nextButton;
    //public GameObject prevButton;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int pageNumber;
    public GameObject highlighter;
    //public GameManager gameManager;


    public void onNextBtnClick()
    {
        //highlighter.transform.GetChildCount
        mainText.text = displayText;
        lastText.gameObject.SetActive(false);
        image.sprite = altImage;
        gameObject.SetActive(false);
        nextButton.SetActive(true);

       // Debug.Log(pageNumber);

        if ( pageNumber == 5)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }

    public void onPageToggleBtnClick()
    {
        mainText.text = displayText;
        lastText.gameObject.SetActive(false);
        image.sprite = altImage;
        GameManager.Instance.turnOffHighlighter();
        this.highlighter.SetActive(true);
        GameManager.Instance.currentPageNumber = pageNumber;
        Debug.Log("current page while clicking on page button  " +pageNumber);


        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
