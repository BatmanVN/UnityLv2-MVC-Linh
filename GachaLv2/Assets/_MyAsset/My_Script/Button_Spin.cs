using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Gacha2D
public class Button_SpinRandom : MonoBehaviour
{
    [SerializeField] private GameObject rewardBar;
    [SerializeField] private GameObject wheel;
    [SerializeField] private float angle;
    [SerializeField] private int prizeNumber;
    [SerializeField] private float time;
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float subSpeed;
    [SerializeField] private float Speed;
    [SerializeField] private AudioSource spinAudio;

    private bool isSpin;
    private void Start()
    {

    }
    private void SpinButton()
    {
        subSpeed += Speed;
        wheel.transform.Rotate(0, 0, time * subSpeed);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            spinAudio.Pause();
            isSpin = false;
            rewardBar.SetActive(true);
        }
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
            subSpeed = defaultSpeed;
            spinAudio.Play();
        }
    }
}