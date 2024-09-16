using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
    [SerializeField] private Text textGift;
    private bool isTrigger;

    public bool IsTrigger { get => isTrigger; set => isTrigger = value; }
    public Text TextGift { get => textGift; set => textGift = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pointer"))
        {
            IsTrigger = true;
            Debug.Log(textGift.text);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pointer"))
        {
            IsTrigger = false;
        }
    }
}
