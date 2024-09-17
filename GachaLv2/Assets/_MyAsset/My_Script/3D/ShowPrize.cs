using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrize : MonoBehaviour
{
    [SerializeField] private Text showGift;
    
    public void DisplayPrize(int prize)
    {
        showGift.text = prize.ToString();
    }
}
