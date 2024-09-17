using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    [SerializeField] private List<Gift> gifts = new List<Gift>();
    [SerializeField] private RewardBar showReward;
    [SerializeField] private GameObject rewardBar;
    private void Display()
    {
        foreach (Gift gift in gifts)
        {
            if(gift.IsTrigger)
            {
                showReward.ShowGift.text = gift.TextGift.text;
            }
        }
    }
    public void EnableBar()
    {
        rewardBar.SetActive(true);
    }
    private void Update()
    {
        Display();
    }
}
