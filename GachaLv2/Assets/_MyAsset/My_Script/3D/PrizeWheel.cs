using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeWheel : MonoBehaviour
{
    [SerializeField] private int prizeNumber;
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;
    [SerializeField] private float minNega;
    [SerializeField] private float maxNega;
    private bool active;
    public int PrizeNumber { get => prizeNumber; set => prizeNumber = value; }
    public bool Active { get => active; set => active = value; }

    public void SetAngle(float angle)
    {
        if (angle >= minNega && angle < maxNega ||angle > minPos && angle <= maxPos)
        {
            Active = true;
        }
        else
            Active = false;
    }
}
