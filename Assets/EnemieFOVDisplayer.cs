using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieFOVDisplayer : MonoBehaviour
{
    LayerMask enemyLayerMask;

    private void OnEnable()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemie");
        foreach(GameObject enemie in enemies)
        {
            enemie.GetComponentInChildren<FieldOfView>().ShowFOV(true);
        }
    }

    private void OnDisable()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemie");
        foreach (GameObject enemie in enemies)
        {
            enemie.GetComponentInChildren<FieldOfView>().ShowFOV(false);
        }

    }

}
