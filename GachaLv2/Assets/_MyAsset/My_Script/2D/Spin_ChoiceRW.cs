using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_ChoiceRW : MonoBehaviour
{
    [SerializeField] private ChoiceGift gift;
    [SerializeField] private GameObject rewardBar;
    [SerializeField] private GameObject wheel;
    [SerializeField] private float targetAngle;
    [SerializeField] private float time;
    [SerializeField] private float firstSpeed;
    [SerializeField] private float downSpeed;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource spinAudio;
    private bool isSpin;
    private void Start()
    {
        targetAngle = gift.Angle;
    }
    private void SpinButton()
    {
        time -= Time.deltaTime;
        if (time > 3)
        {
            wheel.transform.Rotate(0, 0, firstSpeed);
        }
        else if (time <= 3)
        {
            downSpeed -= speed;
            if (downSpeed <= targetAngle)
                {
                    isSpin = false;
                }
            wheel.transform.rotation = Quaternion.Euler(0, 0, downSpeed);
        }
        //if (time <= 0)
        //{
        //    spinAudio.Pause();
        //    isSpin = false;
        //    rewardBar.SetActive(true);
        //}
    }
    private void FixedUpdate()
    {
        if (isSpin)
        {
            SpinButton();
        }
    }
    public void StartWheel()
    {
        rewardBar.SetActive(false);
        if (!isSpin)
        {
            time = Random.Range(4, 6);
            isSpin = true;
            firstSpeed = 20f;
            spinAudio.Play();
        }
    }
}
