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
    [SerializeField] private float downTime;
    [SerializeField] private float firstSpeed;
    [SerializeField] private int spinRound;
    [SerializeField] private int power;
    [SerializeField] private AudioSource spinAudio;
    private bool isSpin;
    private void Start()
    {

    }
    private void SpinButton()
    {
        downTime += Time.deltaTime;
        float timeCount = CalEndtime(downTime / time);
        float changeSpeed = Mathf.Lerp(0f,firstSpeed, timeCount);
        wheel.transform.eulerAngles = new Vector3(0, 0, changeSpeed);
        //wheel.transform.Rotate(0, 0, changeSpeed*Time.deltaTime);
        if ((time - downTime) < 0.001f)
        {
            wheel.transform.rotation = Quaternion.Euler(0,0,gift.Angle);
            isSpin = false;
            rewardBar.SetActive(true);
            spinAudio.Pause();
        }
    }
    private float CalEndtime(float x)
    {
        return 1 - Mathf.Pow(1-x,power);
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
            downTime = 0;
            firstSpeed = 360 * spinRound +  gift.Angle;
            spinAudio.Play();
        }
    }
}
