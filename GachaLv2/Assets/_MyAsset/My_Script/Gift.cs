using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private bool isPrize;

    public bool IsPrize { get => isPrize;}

    public void ShowName(float angle)
    {
        if (angle >= min && angle < max)
        {
            isPrize =true;
        }
        else
            isPrize = false;
    }
    public float RandonAngle(float angle)
    {
        angle = Random.Range(min, max);
        return angle;
    }
}
