using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] color;

    public void Change(int colorID)
    {
        if (colorID < 0) return;
        if (colorID >= color.Length) return;
        GetComponent<MeshRenderer>().material.color = color[colorID];

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
