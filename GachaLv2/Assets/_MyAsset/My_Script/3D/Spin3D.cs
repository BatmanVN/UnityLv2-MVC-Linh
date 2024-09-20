using JSG.FortuneSpinWheel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements.Experimental;

//Gacha3D
public class Spin3D : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    [SerializeField] private Camera maincamera;
    [SerializeField] private GameObject spin;
    [SerializeField] private ChoiceGift gift;
    [SerializeField] private GameObject rewardBar;
    [SerializeField] private float time;
    [SerializeField] private float firstSpeed;
    [SerializeField] private int roundSpin;
    [SerializeField] private float downTime;
    [SerializeField] private AudioSource spinAudio;
    private bool isSpining;


    private void Update()
    {
        if (isSpining)
        {
            RotateWheel();
        }
        else
            SpinWheel();
    }
    private void RotateWheel()
    {
        downTime += Time.deltaTime;
        float easing = EaseOutQuint(downTime / time);
        float speed = Mathf.Lerp(0f, firstSpeed, easing);
        wheel.transform.eulerAngles = new Vector3(0,0, speed);
        if((time - downTime) < 0.01f)
        {
            wheel.transform.rotation = Quaternion.Euler(0, 0, gift.Angle);
            spinAudio.Pause();
            isSpining = false;
            rewardBar.SetActive(true);
        }
    }
    private float EaseOutQuint(float x)
    {
        return 1 - Mathf.Pow(1 - x, 5);
    }
    private void SpinWheel()
    {
        if (!isSpining)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == spin)
                    {
                        SetSpin();
                    }
                }
            }
        }
    }
    private void SetSpin()
    {
        RotateWheel();
        time = UnityEngine.Random.Range(10, 15);
        firstSpeed = 360 * roundSpin + gift.Angle;
        spinAudio.Play();
        isSpining = true;
        downTime = 0;
        rewardBar.SetActive(false);
        UnityEngine.Debug.Log("Angle Set: " + gift.Angle);
    }
}
