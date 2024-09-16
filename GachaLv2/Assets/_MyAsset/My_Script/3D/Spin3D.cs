using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Spin3D : MonoBehaviour
{
    [SerializeField] private float downSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;
    [SerializeField] private float time;
    //[SerializeField] private float min;
    //[SerializeField] private float max;
    private bool isSpining;

    // Update is called once per frame
    private void FixedUpdate()
    {
        RotateWheel();
    }
    private void RotateWheel()
    {
        if (isSpining)
        {
            maxDistance = time * speed;
            transform.Rotate(0, 0, maxDistance, Space.World);
            speed -= downSpeed * Time.deltaTime;
        }
        if (speed <= 0)
        {
            downSpeed = 0;
            isSpining = false;
        }
    }
    public void SpinWheel()
    {
        if (!isSpining)
        {
            time = Random.Range(4f, 6f);
            speed = 5;
            downSpeed = 1;
            isSpining = true;
        }
    }
}
