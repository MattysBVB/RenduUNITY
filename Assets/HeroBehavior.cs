using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class HeroBehavior : MonoBehaviour
{

    public CharacterData characterData;
    public LayerMask layerMask;
    public Transform LeftSide;
    public Transform RightSide;
    public SpriteRenderer spriteRenderer;
    public Animator Anim;
    public GameManager gameManager;
    public GameManager2 gameManager2;
    public GameObject weaponRight;
    public GameObject weaponLeft;
    public heroWeapon weapon;
    public Canvas canvasDied;

    [HideInInspector]
    public float SpeedH;
    [HideInInspector]
    public float JumpForceH;

    private Rigidbody2D _rb;
    private bool _canJump;
    private bool _isHurt;
    private int _currentHealth;
    private bool _isDead;
    private bool _isEmoting;
    private bool _canDash;
    private bool _discussion;
    private int _discussionStep;
    private bool _isAttacking;
    private heroWeapon _hw;
    private bool _getLeTruc;
    private int _leTrucStep;

    // Start is called before the first frame update
    void Start()
    {
        _leTrucStep = 0;
        _getLeTruc = false;
        weaponRight.SetActive(false);
        weaponLeft.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        _isAttacking = false;
        _canJump = false;
        _isHurt = false;
        _isDead = false;
        _isEmoting = false;
        _canDash = false;
        _discussion = false;
        _discussionStep = 0;
        _currentHealth = characterData.MaxHealth;
        SpeedH = characterData.Speed;
        JumpForceH = characterData.JumpForce;
        //weapon.SetActive(false);
        canvasDied.gameObject.SetActive(false);

    }

    void OnValidate()
    {
        spriteRenderer.sprite = characterData.DefaultSprite;
        //_spriteRenderer.sprite
        Anim.runtimeAnimatorController = characterData.Controller;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.82f, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(LeftSide.position, Vector2.down, 0.82f, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(RightSide.position, Vector2.down, 0.82f, layerMask);
        _canJump = hit.collider != null || hit2.collider != null || hit3.collider != null;

        Anim.SetBool("canJump", _canJump);
        if ( _canJump )
        {
            Anim.SetFloat("vSpeed", 0);
        }else
        {
            Anim.SetFloat("vSpeed", _rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) && _isHurt == false && _isDead == false)
        {
            _isEmoting = false;
            _rb.velocity = new Vector2(-SpeedH, _rb.velocity.y);
            Anim.SetBool("Run", true);
            spriteRenderer.flipX = true;
        } else if (Input.GetKey(KeyCode.D) && _isHurt == false && _isDead == false)
        {
            _isEmoting = false;
            _rb.velocity = new Vector2(SpeedH, _rb.velocity.y);
            spriteRenderer.flipX = false;
            Anim.SetBool("Run", true);


        }
        else if (_canJump && _isDead == false)
        {

            _rb.velocity = new Vector2(0, _rb.velocity.y);
            Anim.SetBool("Run", false);
            _canDash = true;
        }
        else if (!_canJump && _isDead == false)
        {
            if (Input.GetKey(KeyCode.LeftShift) && _canDash == true)
            {
                float xSpeed = _rb.velocity.x;

                if(xSpeed > 0)
                {
                    _rb.velocity = new Vector2(SpeedH * 2.5f, _rb.velocity.y/2);
                    _canDash = false;
                }
                else if (xSpeed < 0)
                {
                    _rb.velocity = new Vector2(-SpeedH * 2.5f, _rb.velocity.y/2);
                    _canDash = false;
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && _isDead == false && _canJump)
        {
                    
            _rb.AddForce(Vector2.up * JumpForceH);

            Anim.SetBool("Jump", true);
        }

        if(Input.GetMouseButtonDown(0) && _isDead == false)
        {
            Anim.SetTrigger("Attack");
            if (spriteRenderer.flipX == true)
            {
                _hw = Instantiate(weapon, weaponLeft.transform.position,Quaternion.identity);
                
            }
            else
            {
                _hw = Instantiate(weapon, weaponRight.transform.position, Quaternion.identity);

            }
        }

        if (_discussion)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_discussionStep == 0)
                {
                    gameManager.discussionPanelText1.SetActive(true);
                    gameManager.discussionText1.SetActive(true);
                    _discussionStep = 1;
                } else if (_discussionStep == 1)
                {
                    gameManager.discussionPanelText1.SetActive(false);
                    gameManager.discussionText1.SetActive(false);

                    gameManager.discussionPanelText2.SetActive(true);
                    gameManager.discussionText2.SetActive(true);

                    _discussionStep = 2;
                } else if (_discussionStep == 2) 
                {
                    gameManager.discussionPanelText2.SetActive(false);
                    gameManager.discussionText2.SetActive(false);

                    gameManager.discussionPanelText1.SetActive(true);
                    gameManager.discussionText3.SetActive(true);

                    _discussionStep = 3;
                } else if (_discussionStep == 3) 
                {
                    gameManager.discussionPanelText2.SetActive(false);
                    gameManager.discussionText2.SetActive(false);

                    gameManager.discussionPanelText1.SetActive(true);
                    gameManager.discussionText3.SetActive(true);

                    _discussionStep = 4;
                } else if (_discussionStep == 4)
                {
                    gameManager.discussionPanelText1.SetActive(false);
                    gameManager.discussionText3.SetActive(false);

                    gameManager.discussionPanelText2.SetActive(true);
                    gameManager.discussionText4.SetActive(true);

                    _discussionStep = 5;
                } else if ( _discussionStep == 5)
                {
                    gameManager.discussionPanelText2.SetActive(false);
                    gameManager.discussionText4.SetActive(false);
                    gameManager.discussionPanel.SetActive(false);
                    gameManager.discussionImageStatue.SetActive(false);
                    gameManager.discussionImageHero.SetActive(false);

                    _discussion = false;
                }
            }
            
        }

        if (_getLeTruc)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_leTrucStep == 0)
                {
                    gameManager2.discussionPanelText1.SetActive(true);
                    gameManager2.discussionText3.SetActive(true);
                    _leTrucStep = 1;
                }
                else if (_leTrucStep == 1)
                {
                    gameManager2.discussionText3.SetActive(false);
                    gameManager2.discussionText4.SetActive(true);

                    _leTrucStep = 2;
                }
                else if (_leTrucStep == 2)
                {
                    gameManager2.discussionText4.SetActive(false);
                    gameManager2.discussionText5.SetActive(true);

                    _leTrucStep = 3;
                }
                else if (_leTrucStep == 3)
                {
                    gameManager2.discussionText4.SetActive(false);
                    gameManager2.discussionPanel.SetActive(false);
                    gameManager2.discussionPanel.SetActive(false);
                    gameManager2.discussionImageHero.SetActive(false);
                    _getLeTruc = false;
                    SceneManager.LoadScene(0);
                }

            }
        }




    }

    public void Damage(int Amount)
    {
        if(_currentHealth - Amount <= 0)
        {
            _isDead = true;
            Anim.SetTrigger("Dead");
            canvasDied.gameObject.SetActive(true);

        }else
        {
            _currentHealth -= Amount;
            _isHurt = true;
            StartCoroutine(waitDamage());
            if (_rb.velocity.x > 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.left * SpeedH * 5);
                _rb.AddForce(Vector2.up * JumpForceH * 0.5f);
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.right * SpeedH * 5);
                _rb.AddForce(Vector2.up * JumpForceH * 0.5f);
            }
        }
        
    }

    public IEnumerator waitDamage()
    {
        yield return new WaitForSeconds(0.4f);
        _isHurt = false;

    }


    public void beginDiscussion()
    {
        gameManager.discussionPanel.SetActive(true);
        gameManager.discussionImageStatue.SetActive(true);
        gameManager.discussionImageHero.SetActive(true);

        _discussion = true;
    }

    public void beginLeTruc()
    {
        gameManager2.discussionPanel.SetActive(true);
        gameManager2.discussionImageHero.SetActive(true);
        gameManager2.discussionImageLeTruc.SetActive(true);
        _getLeTruc = true;
    }



}
