using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuickType;
using System.IO;
using TMPro;

public class PanelController : MonoBehaviour
{
    string path = "iphone8battery";
    int stepNo;


    [SerializeField] GameObject title;
    [SerializeField] GameObject description;
    [SerializeField] GameObject stepNumber;

    [SerializeField] GameObject square1;
    [SerializeField] GameObject square2;
    [SerializeField] GameObject square3;

    Test txt;

    void LoadJson()
    {
        var jsonString = Resources.Load(path) as TextAsset;
        txt = Test.FromJson(jsonString.text);
        Debug.Log(jsonString.text);
        
    }

    void Start()
    {
        stepNo = 0;
        LoadJson();
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

        var blankImage = "https://pictureserver.net/images/pic/f0/eb/undef_src_sa_picid_717652_x_1000_type_whitesh_image.jpg?ver=14";
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

    public void Button1()
    {
        path = "iphone8battery";
        Start();
    }

    public void Button2()
    {
        path = "samsungnote3battery";
        Start();
    }

    public void Button3()
    {
        path = "xiaomimi9battery";
        Start();
    }



    // Update is called once per frame
    void Update()
    {
    }
}
