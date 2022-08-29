using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputBoxScript : MonoBehaviour
{
    public InputField userInp;
    public string inpData = "";
    //public GameObject displayContent; 
    public void onSubmitBtnClick()
    {
        inpData = userInp.text ;
        userInp.text = "";
        Debug.Log(inpData);
        PlayerPrefs.SetString("username", inpData);
    }
    void Start()
    {
        

       // Debug.Log(PlayerPrefs.GetString("username", string.Empty));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
