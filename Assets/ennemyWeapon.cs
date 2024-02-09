using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyWeapon : MonoBehaviour
{

    public SpriteRenderer sprite;
    public int damageDeal;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HeroBehavior>().Damage(damageDeal);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
