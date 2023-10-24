using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopGirdi"))
        {
            gameObject.SetActive(false);
        }else if (collision.gameObject.CompareTag("OyunBitti"))
        {
            gameObject.SetActive(false);
        }
    }
}
