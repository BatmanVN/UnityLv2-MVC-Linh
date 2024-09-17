using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] private List<PrizeWheel> prizes = new List<PrizeWheel>();
    [SerializeField] private Transform wheel;
    [SerializeField] private ShowPrize showP;
    [SerializeField] private int prize;
    [SerializeField] private float angle;
    //private int index;
    //private bool active;
    private void Start()
    {
        wheel = GameObject.FindGameObjectWithTag("Wheel").GetComponent<Transform>();
    }
    private void SetPrize()
    {
        angle = wheel.eulerAngles.x;
        if (angle > 180)
        {
            angle -= 360;
        }
        Debug.Log("Angle: " + angle);
        foreach (PrizeWheel wheel in prizes)
        {
            wheel.SetAngle(angle);
            if (wheel.Active)
            {
                prize = wheel.PrizeNumber;
                showP.DisplayPrize(prize);
            }
        }
    }
    private void Update()
    {
        SetPrize();
    }
}
