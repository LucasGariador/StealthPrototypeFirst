using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    public Image background;


    [SerializeField]
    GameObject tool; //Weapon or magic

    void Start()
    {
        background.color = baseColor;
    }
    
    public void Select()
    {
        background.color = hoverColor;
    }

    public void Deselect()
    {
        background.color = baseColor;
    }

    public void SelectItem()
    {
        tool.SetActive(true);
    }

    public void DeselectItem()
    {
        tool.SetActive(false);
    }

}
