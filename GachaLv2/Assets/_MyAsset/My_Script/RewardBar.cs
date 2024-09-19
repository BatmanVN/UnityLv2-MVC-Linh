using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardBar : MonoBehaviour
{
    [SerializeField] private Text showGift;

    public void DisplayReward(string giftName)
    {
        showGift.text = giftName;
    }

}
