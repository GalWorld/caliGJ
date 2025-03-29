using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isDiverRescued = false;

    void Start()
    {
        isDiverRescued = false;
        Debug.Log("Estado de rescate del buzo: " + isDiverRescued);
    }

}
