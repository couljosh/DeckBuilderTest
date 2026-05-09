using UnityEngine;

public class HandManagement : MonoBehaviour
{
    [Header("Hand Tracking References")]
    public static HandManagement instance;
    public Transform[] handSlots;
    public int handCount;


    public Transform GetNewSlot()
    {
        if(handCount >= handSlots.Length)
            return null;

        return handSlots[handCount++];
        
    }


    void Awake()
    {
        instance = this;   
    }

}
