using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneStatueBehavior : MonoBehaviour
{
    public HeroBehavior hB;
    private bool _stopPlayer;
    private bool _firstTime;

    public void Start()
    {
        _stopPlayer = false;
        _firstTime = true ;
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _firstTime)
        {
            _firstTime = true;
            hB.beginDiscussion();
        }
    }
}
