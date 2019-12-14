using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject creditsUI;
    public GameObject menuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


    public void Credits()
    {
        creditsUI.SetActive(true);
        menuUI.SetActive(false);


    }

    public void Credits_Back()
    {
        creditsUI.SetActive(false);
        menuUI.SetActive(true);

    }
}

  
