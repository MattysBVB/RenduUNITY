using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject discussionPanel;
    public GameObject discussionImageStatue;
    public GameObject discussionImageHero;

    private bool _discussionDone;
    private bool discussionSend;

    private int _discussionIterator;
    
    public GameObject discussionText1;
    public GameObject discussionText2;
    public GameObject discussionText3;
    public GameObject discussionText4;
    public GameObject discussionPanelText1;
    public GameObject discussionPanelText2;

    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        discussionImageStatue.SetActive(false);
        discussionPanel.SetActive(false);
        discussionImageHero.SetActive(false);
        _discussionDone = false;
        _discussionIterator = 0;
        discussionText1.SetActive(false);
        discussionText2.SetActive(false);
        discussionText3.SetActive(false);
        discussionText4.SetActive(false);
        discussionPanelText1.SetActive(false);
        discussionPanelText2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void discussion()
    {
        if(!_discussionDone)
        {
            bool discussionNotFinish = true;
            int stateDiscussion = 0;

            discussionPanel.SetActive(true);
            discussionImageStatue.SetActive(true);
            discussionImageHero.SetActive(true);
            while(!_discussionDone) 
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    _discussionDone = true;
                }
            }
        }


       
    }
}
