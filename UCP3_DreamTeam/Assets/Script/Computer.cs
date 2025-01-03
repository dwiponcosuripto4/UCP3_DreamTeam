using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.localPosition.z <= 6.0f && ball.localPosition.z >= -6.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ball.position.z);
        }
    }
}
