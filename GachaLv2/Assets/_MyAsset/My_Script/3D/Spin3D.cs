using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

//Gacha3D
public class Spin3D : MonoBehaviour
{
    [SerializeField] private GameObject rewardObj;
    [SerializeField] private float setPrize;
    [SerializeField] private float maxDistance;
    [SerializeField] private float defaultDistance;
    [SerializeField] private float speed;
    [SerializeField] private float time;
    private bool disable;
    private bool isSpining;


    private void FixedUpdate()
    {
        RotateWheel();
    }
    private void RotateWheel()
    {
        if (isSpining && time > 0)
        {
            maxDistance += speed;
            time -= 1 * Time.deltaTime;
            if (time < 2.5f)
            {
                if (time < 0 || maxDistance <0) return;
                maxDistance -= speed*2.5f;
            }
            transform.Rotate(0, maxDistance*Time.deltaTime, 0);
        }
        if (time <= 0)
        {
            transform.rotation = Quaternion.Euler(setPrize, 90, 90);
            isSpining = false;
            if(!disable)
            {
                rewardObj.SetActive(true);
                disable = true;
            }
        }
    }
    public void SpinWheel()
    {
        disable = false;
        if (!isSpining)
        {
            time = Random.Range(4f, 6f);
            speed = Random.Range(5, 10);
            setPrize = Random.Range(0,360);
            maxDistance = defaultDistance;
            isSpining = true;
        }
    }
}
