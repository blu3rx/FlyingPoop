using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{


    private static gameController instance;

   
  
    private bool _gameOver = false;
    private int _score=1;

    [Header("Text")]
    public Text scoreText;


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
        }

        scoreText.text = _score.ToString();

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
