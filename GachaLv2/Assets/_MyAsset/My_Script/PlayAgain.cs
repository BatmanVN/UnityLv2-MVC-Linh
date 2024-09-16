using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] private GameObject rewardBar;

    public void DisableBar()
    {
        rewardBar.SetActive(false);
    }
}
