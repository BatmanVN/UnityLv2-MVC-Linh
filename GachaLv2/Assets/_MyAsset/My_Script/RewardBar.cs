using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardBar : MonoBehaviour
{
    [SerializeField] private Text showGift;

    public Text ShowGift { get => showGift; set => showGift = value; }

    private void Update()
    {
        Debug.Log(showGift.text);
    }
}
