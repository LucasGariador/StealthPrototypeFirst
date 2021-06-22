using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    Vector2 normalisedMousePosition;
    float currentAngle;
    public int selection;
    private int previousSelection;

    public GameObject[] menuItems;

    private MenuItem menuItemSc;
    private MenuItem previousMenuItemSc;


    void Update()
    {
        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 90;

        if(selection != previousSelection)
        {
            previousMenuItemSc = menuItems[previousSelection].GetComponent<MenuItem>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<MenuItem>();
            menuItemSc.Select();
        }

        if (Input.GetMouseButtonDown(0))
        {
            for(int i = 0; i < menuItems.Length; i++)
            {
                menuItems[i].GetComponent<MenuItem>().DeselectItem();
            }
            menuItemSc.SelectItem();
        }
    }
}
