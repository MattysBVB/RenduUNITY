using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public GameObject goalObject;
    public GameObject goalText;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.transform.position = new Vector3(x, y, z);
            goalObject.SetActive(true);
            goalText.SetActive(true);
            //hero.transform.position =new Vector3(x, y, z);
        }
    }
}
