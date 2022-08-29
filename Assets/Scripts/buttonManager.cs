using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    public Text mainText;
    public string initialText = "";
    void Start()
    {
        mainText.text = initialText;
    }

    // Update is called once per frame
    void Update()
    {
       // mainText.text = "updated text";
    }

    /*public void onBtnClick()
    {
        mainText.text = "You clicked on 1st button";
    }

    public void onSecondBtnClick()
    {
        secondText.text = "you clicked on 2nd button";
    }
    */
    public void printText(string text)
    {
        mainText.text = text;

    }
}
