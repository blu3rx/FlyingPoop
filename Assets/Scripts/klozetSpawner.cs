using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klozetSpawner : MonoBehaviour
{
    [Header("Floats")]

    public float maxTime = 1;
    private float timer = 0;
    public float height;


    [Header("GameObjects")]
    public GameObject klozet;

    private void Start()
    {
       GameObject newklozet = Instantiate(klozet);
       newklozet.transform.position = transform.position + new Vector3(0, Random.Range(height, -height), 0);
       Destroy(newklozet, 15);

    }

    private void Update()
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
}
