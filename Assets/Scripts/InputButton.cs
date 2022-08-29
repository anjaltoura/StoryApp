using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
    public Text DisplayText;
    public InputField input;
    public Image Image;
    public Sprite alternateImage;


    public void OnButtonClick()
    {
        DisplayText.text = input.text;
        //input.text="";
        Image.sprite = alternateImage;
    }

}
