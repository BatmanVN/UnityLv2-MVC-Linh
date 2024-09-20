using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GiftManager : MonoBehaviour
{
    [SerializeField] private List<Gift> gifts = new List<Gift>();
    [SerializeField] private RewardBar showReward;
    [SerializeField] private GameObject wheel;
    [SerializeField] private float angle;

    private void CaculatorAngle()
    {
        angle = wheel.transform.eulerAngles.z;
        if (angle < 0)
        {
            angle += 360;
        }
        Debug.Log("Change Angle: " + angle);
    }
    private void CanCollectPrize()
    {
        CaculatorAngle();
        foreach (Gift gift in gifts)
        {
            gift.ShowName(angle);
            if (gift.IsPrize)
            {
                showReward.DisplayReward(gift.name);
            }
        }
    }
    private void Update()
    {
        CanCollectPrize();
    }
}
