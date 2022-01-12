using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuickType;
using System.IO;
using TMPro;

public class test : MonoBehaviour
{
    string path = "Assets/jsonformatter.txt";
    [SerializeField] GameObject textPanel;

    Test Write()
    {
        StreamReader reader = new StreamReader(path);
        var jsonString = reader.ReadToEnd();
        Test txt = Test.FromJson(jsonString);
        Debug.Log(jsonString);
        return txt;
    }

    // Start is called before the first frame update
    void Start()
    {
        textPanel.GetComponent<TextMeshProUGUI>().text = Write().Author.Username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
