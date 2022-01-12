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

    Test Write()
    {
        var jsonString = Resources.Load(path) as TextAsset;
        Test txt = Test.FromJson(jsonString.text);
        Debug.Log(jsonString.text);
        return txt;
    }

    void Start()
    {
        title.GetComponent<TextMeshProUGUI>().text = Write().Title.ToString();
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
        for(int i = 0; i < Write().Steps[stepNo].Lines.Length; i++)
        {
            descr += $"{i+1}. {Write().Steps[stepNo].Lines[i].TextRaw} \n\n";
        }
        
        description.GetComponent<TextMeshProUGUI>().text = descr;

        stepNumber.GetComponent<TextMeshProUGUI>().text = "Step Number: " + (stepNo+1).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
