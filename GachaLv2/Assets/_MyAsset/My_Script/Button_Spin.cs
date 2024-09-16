using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Button_Spin : MonoBehaviour
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
        spinWheel += Time.deltaTime * new Vector3(0, 0, angleSpeed);
        transform.eulerAngles = spinWheel;
        time -= Time.deltaTime;
    }

    private void SetTime()
    {
        if (time > time / 2)
        {
            angleSpeed++;
        }
        if (time <= time / 1.5)
        {
            angleSpeed -= 2;
            if (angleSpeed <= angleRoll)
            {
                isSpin = false;
                onEnable?.Invoke();
                spinAudio.Pause();
            }
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