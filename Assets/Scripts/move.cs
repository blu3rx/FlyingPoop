using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        speed = gameController.Instance.MoveSpeed;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
