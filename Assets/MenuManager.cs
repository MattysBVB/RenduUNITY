using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject btnContinue;
    private int actualLevel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewAdventure()
    {
        SceneManager.LoadScene(1);
    }

    public void Futbol()
    {
        SceneManager.LoadScene(3);
    }
}
