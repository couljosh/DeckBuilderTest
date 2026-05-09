using System.Collections.Generic;
using UnityEngine;

public class HandManagement : MonoBehaviour
{
    [Header("Hand Tracking References")]
    public static HandManagement instance;
    public Transform[] handSlots;
    public int handCount;

    [Header("Complete Hand")]
    public GameObject continueCanvas;
    void Awake()
    {       
        handCount = 0;

        instance = this;   

        continueCanvas.SetActive(false);
    }

    public Transform GetNewSlot()
    {
        if(handCount >= handSlots.Length - 1)
        {
            continueCanvas.SetActive(true);
        }     

        return handSlots[handCount++];
        
    }

}
