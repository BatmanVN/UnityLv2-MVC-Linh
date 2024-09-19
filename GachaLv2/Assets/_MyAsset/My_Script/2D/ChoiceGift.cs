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
        GiftSelected();
    }
    public void GiftSelected()
    {
        for (int i = 0; i < gifts.Count; i++)
        {
            if (i == choiceGift)
            {
                Angle = gifts[choiceGift].RandonAngle(Angle);
                showReward.DisplayReward(gifts[choiceGift].name);
                Debug.Log("Angle: Choice " + Angle);
                break;
            }
        }
    }
    private void Update()
    {
        
    }
}
