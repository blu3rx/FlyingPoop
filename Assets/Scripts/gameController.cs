using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{


    private static gameController instance;

   
  
    private bool _gameOver = false;
    private int _score=1;

    [Header("GameObject")]
    public GameObject restartMenuUI;
    public GameObject pauseButton;
    public GameObject gameOverMenu;




    [Header("Text")]
    public Text scoreText;

    [Header("SoundSource")]
    public AudioSource deadFart;

    public void Awake()
    {

        if (instance != null)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (_gameOver)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
            deadFart.Play();
            _gameOver = false;
        }

        scoreText.text = _score.ToString();

        if (Time.timeScale == 1)
            pauseButton.SetActive(true);
        else if(Time.timeScale==0)
            pauseButton.SetActive(false);

    }




    public static gameController Instance
    {
        get
        {
            instance = FindObjectOfType<gameController>();

            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "GameController";
                instance = go.AddComponent<gameController>();

            }
            return instance;
        }
    }

    public void Restart()
    {
        restartMenuUI.SetActive(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        restartMenuUI.SetActive(true);    
        Time.timeScale = 0;
       
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);

    }
    public void Resume()
    {
        if (_gameOver == false)
        {
            restartMenuUI.SetActive(false);
            Time.timeScale = 1;
        }
    }



    public bool GameOver
    {
        get
        {
            return _gameOver;
        }
        set
        {
            _gameOver = value;
        }
    }
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }




}
