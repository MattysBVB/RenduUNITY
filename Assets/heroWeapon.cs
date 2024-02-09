using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroWeapon : MonoBehaviour
{
    public int damageDeal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            collision.gameObject.GetComponent<Ennemy>().Damage(damageDeal);
        }


    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            ("Marche");
            collision.gameObject.GetComponent<Ennemy>().Damage(damageDeal);
        }
    }*/

    public IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

        //weaponLeft.SetActive(_isAttacking);
        //weaponRight.SetActive(_isAttacking);


    }
}
