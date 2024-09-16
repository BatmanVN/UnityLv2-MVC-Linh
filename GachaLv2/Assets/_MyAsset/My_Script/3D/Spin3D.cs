using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spin3D : MonoBehaviour
{
    private Vector3 spinWheel;
    [SerializeField] private float angleRoll;
    [SerializeField] private float angleSpeed;
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
        SetTime();
        spinWheel = new Vector3(angleSpeed, -90, 90);
        transform.eulerAngles = spinWheel;
        time -= Time.deltaTime;
    }

    private void SetTime()
    {
        if (time > time / 2)
        {
            angleSpeed += 5;
        }
        if (time <= time / 1.5)
        {
            angleSpeed -= 5;
            if (angleSpeed <= angleRoll)
            {
                isSpin = false;
                onEnable?.Invoke();
                spinAudio.Pause();
            }
        }
    }
    private void Update()
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
            angleRoll = Random.Range(360, 720);
            isSpin = true;
            spinAudio.Play();
        }
    }
}