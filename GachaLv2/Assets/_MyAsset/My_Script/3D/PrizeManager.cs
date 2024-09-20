using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] private List<Gift> gifts = new List<Gift>();
    [SerializeField] private Transform wheel;
    [SerializeField] private RewardBar showP;
    [SerializeField] private int prize;
    [SerializeField] private float angle;
    //private int index;
    //private bool active;
    private void Start()
    {
        
    }
    private void SetPrize()
    {
        angle = wheel.eulerAngles.z;
        if (angle > 180)
        {
            angle -= 360;
        }
        foreach (Gift gift in gifts)
        {
            gift.ShowName(angle);
            if (gift.IsPrize)
            {
                showP.DisplayReward(gift.name);
            }
        }
    }
    private void Update()
    {
        SetPrize();
    }
}
