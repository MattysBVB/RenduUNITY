using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leTruc : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HeroBehavior>().beginLeTruc();
        }


    }
}
