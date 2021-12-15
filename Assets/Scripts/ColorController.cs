using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color selected;
    [SerializeField] private Color deselected;

    public void Select()
    {
        GetComponent<MeshRenderer>().material.color = this.selected;
    }

    public void Deselect()
    {
        GetComponent<MeshRenderer>().material.color = this.deselected;
    }


}
