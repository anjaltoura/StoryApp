using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton <GameManager>
{
    public GameObject mainScreen;
    public List<GameObject> defaultObjectsToBeVisible;
    public Text gameManagerText;
    public Image gameManagerImage;
    public string defaultText;
    public Sprite defaultImage;
    public GameObject usernameInputPanel;
    public GameObject usernameDisplayPanel;
    public Text usernameDisplayText;
    public int pageNumber;
    public int currentPageNumber, nextPage;
    //public int pageNumber;
    public GameObject content; 


   
    public void onCloseBtnClick()
    {
        Application.Quit();
    }

    public void onRestartBtnClick ()
    {
        foreach(Transform child in mainScreen.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (GameObject defaultGameObject in defaultObjectsToBeVisible)
        {
            defaultGameObject.SetActive(true);
        }

        gameManagerText.text = defaultText;
        gameManagerImage.sprite = defaultImage;

        turnOffHighlighter();
        content.transform.GetChild(0).GetComponent<storyScript>().highlighter.SetActive(true); //getting child of content, ie: button 1, then getting into script component and selecting highlighter and turning it onn 


    }
    void Start()
    {
        string savedUsername = PlayerPrefs.GetString("username", string.Empty);
        if (string.IsNullOrEmpty(savedUsername))
        {
            usernameInputPanel.SetActive(true);
           // usernameDisplayText.text = "Welcome " + savedUsername;
        }
        else
        {
            usernameDisplayPanel.SetActive(true);
            usernameDisplayText.text = "Welcome " + savedUsername;

        }
        //content.transform.GetChild(0).GetComponent<storyScript>().highlighter.SetActive(true);
    }

    public void onStartStoryButtonClick()
    {
        usernameDisplayPanel.SetActive(false);
        mainScreen.SetActive(true);
       // onRestartBtnClick();

    }

    public void onNextButtonClick()
    {
        Debug.Log("current page number " + currentPageNumber);
        nextPage = currentPageNumber + 1;
        Debug.Log("nextpage "+ nextPage);
        

        GameManager.Instance.content.transform.GetChild(currentPageNumber).GetComponent<storyScript>().onPageToggleBtnClick();

    }


    public void onUsernameSubmitClick()
    {
        usernameInputPanel.SetActive(false);
        usernameDisplayPanel.SetActive(true);
        string savedUsername = PlayerPrefs.GetString("username", string.Empty);
        usernameDisplayText.text = "Welcome " + savedUsername;
    }

    public void turnOffHighlighter()
    {
        foreach( Transform button in content.transform)
        {
            button.GetComponent<storyScript>().highlighter.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
