using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class teleportBehavior : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    //public HeroBehavior hero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(x, y, z);
            //hero.transform.position =new Vector3(x, y, z);
        }
    }
}
