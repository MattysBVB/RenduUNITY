using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ennemy : MonoBehaviour
{

    public CharacterData characterData;
    public ennemyWeapon weapon;
    public int currentHealth;
    [HideInInspector]
    public float SpeedH;
    [HideInInspector]
    public float JumpForceH;
    public SpriteRenderer spriteRenderer;
    private bool _deplacementRight;
    private bool _active;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        SpeedH = characterData.Speed;
        JumpForceH = characterData.JumpForce;
        _deplacementRight = false;
        _rb = GetComponent<Rigidbody2D>();
        _active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_active)
        {
            StartCoroutine(rightDeplacement());
        }
        
        if (_deplacementRight)
        {
            _rb.velocity = new Vector2(SpeedH, _rb.velocity.y);
            spriteRenderer.flipX = false;

        } else
        {
            _rb.velocity = new Vector2(-SpeedH, _rb.velocity.y);
            spriteRenderer.flipX = true;
        }
    }

    public void Damage(int Amount)
    {
        currentHealth -= Amount;
        if(currentHealth <= 0) 
        {
            Dead();
        }
        else
        {
            StartCoroutine(waitDamage());
        }
        
    }

    public IEnumerator waitDamage()
    {
        yield return new WaitForSeconds(0.5f);

    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator rightDeplacement()
    {
        _active = true;
        yield return new WaitForSeconds(3f);
        _deplacementRight = !_deplacementRight;
        _active = false;
    }


}
