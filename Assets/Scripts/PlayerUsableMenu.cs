using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsableMenu : MonoBehaviour
{
    [SerializeField]
    GameObject WheelMenu;

    PlayerMovement pM;

    bool active = false;

    void Start()
    {
        pM = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Activates and deactivates the menu
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WheelMenuActions();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            WheelMenuActions();
        }

    }
    //Set active the wheel, make the cursor visible and deactivate WASD movement
    void WheelMenuActions()
    {
        active = !active;
        WheelMenu.SetActive(active);
        Cursor.visible = active;
        pM.activeMovement = !active;
    }
}
