using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject ContentPanel;
    public String CustomButtonListJson;
    public Text displayText;
    public Image displayImage;
    List<CustomButton> CustomButtonList;

    public Dictionary<string, GameObject> firstDictionary = new Dictionary<string, GameObject>();

    void Start()
    {

        CustomButtonList customButtonListC = JsonUtility.FromJson<CustomButtonList>(CustomButtonListJson); //CustomButtonList is the structure that needs to be followed while converting CustomButtonListJson (a string) into a class 

        Debug.Log(JsonUtility.ToJson(customButtonListC));

        CustomButtonList = customButtonListC.StoryList;

        for (int i = 0; i < CustomButtonList.Count; i++)
        {
            GameObject InstantiatedButton = Instantiate(buttonPrefab, ContentPanel.transform);
            // InstantiatedButton.transform.parent = mainPanel.transform;
           // InstantiatedButton.transform.localPosition = new Vector3(0f , i * 50f, 0f);
            InstantiatedButton.name = CustomButtonList[i].ButtonName ;

            InstantiatedButton.transform.GetComponent<customButtonUI>().defaultText.text = CustomButtonList[i].ButtonName;
            LoadImage(InstantiatedButton.transform.GetComponent<customButtonUI>().defaultImage, CustomButtonList[i].AltImage); //calling LoadImage Function and passing variable 
           // InstantiatedButton.transform.GetComponent<customButtonUI>().defaultImage.sprite = CustomButtonList[i].altImage;

            int j = i;
            InstantiatedButton.transform.GetComponent<Button>().onClick.AddListener(() => onStoryButtonClick(j, InstantiatedButton.transform.GetComponent<customButtonUI>().highlighter, InstantiatedButton.transform.GetComponent<customButtonUI>().defaultImage));

            firstDictionary.Add(InstantiatedButton.name, InstantiatedButton);
          
        }

    }

    private void LoadImage(Image image, string altImage)
    {
        StartCoroutine(GetTexture(image, altImage));
    }

    IEnumerator GetTexture(Image image, string altImage)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(altImage);
        yield return www.SendWebRequest(); //wait till request clears 

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture; //download texture 
            Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f); //create sprite out of the downloaded texture 
            image.sprite = mySprite;
        }
    }

    void onStoryButtonClick(int j,GameObject highlighter,Image image)
    { 
        displayText.text = CustomButtonList[j].StoryText;
        displayImage.sprite = image.sprite;
        highlighter.GetComponent<Animator>().SetTrigger("ClickTrigger");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



[Serializable]
public class CustomButtonList
{
    public List<CustomButton> StoryList;
}

[Serializable]
public class CustomButton
{
    public String ButtonName;
    public String AltImage;
    public String StoryText;
}
