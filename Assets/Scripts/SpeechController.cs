using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Microsoft.MixedReality.Toolkit.Audio;

public class SpeechController : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    private TextToSpeech speechHandler;

    private void Awake()
    {
        speechHandler = GetComponent<TextToSpeech>();
    }

    public void Speak()
    {
        this.speechHandler.StartSpeaking(this.textMeshPro.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
