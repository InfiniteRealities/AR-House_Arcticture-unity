using UnityEngine;
using System.Collections;

public class ColorPickerTester : MonoBehaviour 
{

    Renderer renderers;
    public ColorPicker picker;
    
	void Start () 
    {
        picker.CurrentColor = transform.GetChild(0).GetComponent<Renderer>().material.color;
        picker.onValueChanged.AddListener(color =>
        {
            foreach (Transform item in transform)
            {
                item.GetComponent<Renderer>().material.color = color;
            }
        });
    }
}
