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
    //[SerializeField] private float downSpeed;
    //[SerializeField] private float speed;
    [SerializeField] private AudioSource spinAudio;
    private bool isSpin;
    private void Start()
    {

    }
    private void SpinButton()
    {
        time -= Time.deltaTime;
        wheel.transform.Rotate(0, 0, firstSpeed*Time.deltaTime);
        if (time <= 9)
        {   // khi time <= 3 thì sẽ lưu góc hiện tại lại
            
            float currentAngle = wheel.transform.eulerAngles.z;
            Debug.Log("Current: " + currentAngle);
            // tính góc còn lại từ currtenAngle đến giftAngle choice
            //float remainAngle = Mathf.DeltaAngle(currentAngle, gift.Angle);
            // targetAngle sẽ dùng lerp để tính toán từ góc Z đã lưu khi time <=3 cho đến góc/gift đã đc chọn
            // và sẽ tính toán từ 0-1 nếu time =3 thì tốc độ vẫn sẽ là firstSpeed, khi time giảm dần tốc độ sẽ giảm dần về 0
            targetAngle = Mathf.Lerp(currentAngle, gift.Angle, (9 - time) /9);
            wheel.transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        }
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
            time = Random.Range(10, 15);
            isSpin = true;
            firstSpeed = (360 * 3 + (2f * gift.Angle)) * -1;
            spinAudio.Play();
        }
    }
}
