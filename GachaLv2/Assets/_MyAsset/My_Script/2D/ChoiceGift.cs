using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceGift : MonoBehaviour
{
    [SerializeField] private List<Gift> gifts = new List<Gift>();
    [SerializeField] private RewardBar showReward;
    [SerializeField] private int choiceGift;
    [SerializeField] private float angle;

    public float Angle { get => angle; set => angle = value; }

    private void Start()
    {
        choiceGift = Random.Range(0, gifts.Count);
        GiftSelected();
    }
    public void GiftSelected()
    {
        if (gifts[choiceGift] != null)
        {
            angle = gifts[choiceGift].RandonAngle(angle);
            showReward.DisplayReward(gifts[choiceGift].name);
        }
    }
    private void Update()
    {
    }
}
