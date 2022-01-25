using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuickType;
using System.IO;
using TMPro;

public class test : MonoBehaviour
{
    string path = "jsonformatter";
    int stepNo = 0;


    [SerializeField] GameObject title;
    [SerializeField] GameObject description;
    [SerializeField] GameObject stepNumber;

    [SerializeField] GameObject square1;
    [SerializeField] GameObject square2;
    [SerializeField] GameObject square3;

    Test txt;

    void Write()
    {
        var jsonString = Resources.Load(path) as TextAsset;
        txt = Test.FromJson(jsonString.text);
        Debug.Log(jsonString.text);
        
    }

    void Start()
    {
        Write();
        title.GetComponent<TextMeshProUGUI>().text = txt.Title.ToString();
        updateContent();
    }

    public void nextButton() 
    {
        stepNo += 1;
        updateContent();
    }
    public void backButton() 
    {
        stepNo -= 1;
        updateContent();
    }

    public void updateContent()
    {
        string descr = "";
        for(int i = 0; i <txt.Steps[stepNo].Lines.Length; i++)
        {
            descr += $"{i+1}. {txt.Steps[stepNo].Lines[i].TextRaw} \n\n";
            description.GetComponent<TextMeshProUGUI>().text = descr;

        }
        
        description.GetComponent<TextMeshProUGUI>().text = descr;

        stepNumber.GetComponent<TextMeshProUGUI>().text = "Step Number: " + (stepNo+1).ToString();

        var blankImage = "https://assets.cdn.ifixit.com/static/images/avatars/User/ifixit/avatar-2.200x150";
        var imgLinksArr = txt.Steps[stepNo].Media.Data;
        var len = imgLinksArr.Length;
        Debug.Log("Images: " + len);

        if (len == 0)
        {
            square1.GetComponent<FetchTexture>().changeImageURL(blankImage);
            square2.GetComponent<FetchTexture>().changeImageURL(blankImage);
            square3.GetComponent<FetchTexture>().changeImageURL(blankImage);
        }
        if (len == 1)
        {
            square1.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[0].Original.AbsoluteUri);
            square2.GetComponent<FetchTexture>().changeImageURL(blankImage);
            square3.GetComponent<FetchTexture>().changeImageURL(blankImage);

        }
        if (len == 2)
        {
            square1.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[0].Original.AbsoluteUri);
            square2.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[1].Original.AbsoluteUri);
            square3.GetComponent<FetchTexture>().changeImageURL(blankImage);
        }
        if (len > 2)
        {
            square1.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[0].Original.AbsoluteUri);
            square2.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[1].Original.AbsoluteUri);
            square3.GetComponent<FetchTexture>().changeImageURL(imgLinksArr[2].Original.AbsoluteUri);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
