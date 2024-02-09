using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject discussionPanel;
    public GameObject discussionImageHero;
    public GameObject discussionPanelText1;
    public GameObject discussionText1;
    public GameObject discussionText2;
    public GameObject discussionImageLeTruc;
    public GameObject discussionText3;
    public GameObject discussionText4;
    public GameObject discussionText5;

    public static GameManager2 Instance;

    private bool _discussionDone;
    private int _discussionStep;

    // Start is called before the first frame update
    void Start()
    {
        _discussionDone = false;
        _discussionStep = 0;
        discussionImageHero.SetActive(true);
        discussionPanelText1.SetActive(false);
        discussionPanel.SetActive(true);
        discussionPanelText1.SetActive(false);
        discussionText2.SetActive(false);
        discussionText3.SetActive(false);
        discussionText4.SetActive(false);
        discussionText5.SetActive(false);
        discussionImageLeTruc.SetActive(false);
        

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_discussionDone)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                if (_discussionStep == 0)
                {
                    discussionPanelText1.SetActive(true);
                    discussionText1.SetActive(true);
                    _discussionStep = 1;
                }
                else if (_discussionStep == 1)
                {
                    discussionText1.SetActive(false);

                    discussionText2.SetActive(true);
                    _discussionStep = 2;
                }
                else if (_discussionStep == 2)
                {
                    discussionText2.SetActive(false);
                    discussionPanelText1.SetActive(false);
                    discussionPanel.SetActive(false);
                    discussionImageHero.SetActive(false);

                    _discussionDone = true;
                }
            }
            
        }
    }

    public void goToMenu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void retry()
    {
        SceneManager.LoadScene(2);
    }
}
