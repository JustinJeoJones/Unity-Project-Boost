using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustSpeed = 1000;
    [SerializeField] float rotateSpeed = 250;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        ProcessThrust();
        ProcessDirection();
    }
    void ProcessThrust()
    {
        //Thrust
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("space");
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
    }

    void ProcessDirection()
    {
        rb.freezeRotation = true; //prevent unity physics from rotate
        //left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("left");
            Rotate(Vector3.forward);
        }
        //right
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Debug.Log("right");
            Rotate(Vector3.back);
        }
        rb.freezeRotation = false; //reallow unity physics  rotate
    }

    void Rotate(Vector3 v)
    {
        rb.transform.Rotate(v * rotateSpeed * Time.deltaTime);
    }
}
