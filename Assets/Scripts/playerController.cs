using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Vectors")]
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    Vector3 position;

    [Header("Floats")]
    public float maxSpeed;
    public float minPositionY;
    public float maxPositionY;



    [Header("Bools")]
    bool didFlap = false;
    bool hit = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            didFlap = true;

        if (hit)
        {
            gameController.Instance.GameOver = true;
            hit = false;
        }


    }
    private void FixedUpdate()
    {
        Phsycis();

    }

    private void Phsycis () 
    {
        velocity += gravity * Time.deltaTime;
        if (didFlap)
        {
            didFlap = false;
            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //Debug.Log("velocity =" + velocity.y);

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, minPositionY, maxPositionY),
            transform.position.z
            );

        if (transform.position.y <= minPositionY || transform.position.y >= maxPositionY)
            hit = true;


        transform.position += velocity * Time.deltaTime;


        float angle = 0;
        if (velocity.y < 0)
            angle = Mathf.Lerp(0, -380, -velocity.y / (maxSpeed * 3f));





        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "klozet")
        {
            hit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "point")
        {
            gameController.Instance.Score++;
        }
    }
}
