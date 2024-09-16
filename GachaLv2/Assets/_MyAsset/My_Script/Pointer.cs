using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Collider2D pointer;

    public void EnableColl()
    {
        pointer.enabled = true;
    }
    public void DisableColl()
    {
        pointer.enabled = false;
    }
}
