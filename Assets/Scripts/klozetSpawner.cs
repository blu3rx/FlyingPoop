using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klozetSpawner : MonoBehaviour
{
    [Header("Floats")]
    public float maxTime = 10;
    private float timer = 0;
    public float height;
    private float score;

    [Header("Int")]
    public int level=0;
    public int levelUp = 80;


    [Header("GameObjects")]
    public GameObject klozet;

    private void Start()
    {
        score = gameController.Instance.Score;

        GameObject newklozet = Instantiate(klozet);
        newklozet.transform.position = transform.position + new Vector3(0, Random.Range(-1, 1), 0);
        Destroy(newklozet, 15);

    }

    private void Update()
    {
        score = gameController.Instance.Score;
        Spawner();
        if (score % levelUp == 0 && level < 10)
            Level();
        //Debug.Log(score);

    }

    private void Spawner()
    {
        if (timer > maxTime)
        {
            GameObject newklozet = Instantiate(klozet);
            newklozet.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newklozet, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void Level()
    {
            maxTime -= 0.18f;
            //height += 0.3f;
            level++;
            gameController.Instance.Score++;
            Debug.Log("Level Up! " + level);
       

    }

}
