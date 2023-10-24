using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopGirdi"))
        {
            gameObject.SetActive(false);
            _GameManager.DevamEt(transform.position);
        }else if (collision.gameObject.CompareTag("OyunBitti"))
        {
            _GameManager.OyunBitti();
            gameObject.SetActive(false);
        }
    }
}
