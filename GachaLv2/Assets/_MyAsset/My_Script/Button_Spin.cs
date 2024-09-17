using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Gacha2D
public class Button_Spin : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    [SerializeField] private float prizeRandom;
    [SerializeField] private float angleSpeed;
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float time;
    [SerializeField] private AudioSource spinAudio;
    [SerializeField] private UnityEvent onEnable;
    [SerializeField] private UnityEvent onDisable;
    private bool isSpin;
    private void Start()
    {

    }
    private void SpinButton()
    {
        if (isSpin && time > 0)
        {
            angleSpeed += 10;
            if (time < 2.5f)
            {
                if (time <= 0 && angleSpeed < 0) return;
                angleSpeed -= 20;//co the dat biet de chinh trong unity cho de
            }

            wheel.transform.Rotate(0, 0, angleSpeed*Time.deltaTime);
        }
        if (time <= 0)
        {
            wheel.transform.eulerAngles = new Vector3(0,0, prizeRandom);
            onEnable?.Invoke();
            spinAudio.Pause();
            isSpin = false;
        }
        time -= Time.deltaTime;
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
        onDisable?.Invoke();
        if (!isSpin)
        {
            time = Random.Range(4, 6);
            isSpin = true;
            prizeRandom = Random.Range(0, 360);
            angleSpeed = defaultSpeed;
            spinAudio.Play();
        }
    }
}