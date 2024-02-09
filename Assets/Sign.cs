using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private bool _isTrigger;
    public GameObject textSign;
    void Start()
    {
        textSign.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textSign.SetActive(true);
        }
        
            
    }
}
