using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "player 2")
        {
            if (Input.GetKey(KeyCode.W) && transform.localPosition.z < 6f)
            {
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.S) && transform.localPosition.z > -6f)
            {
                transform.Translate(0, 0, -speed);
            }
        }

        if (gameObject.name == "player 1")
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.localPosition.z < 6f)
            {
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.localPosition.z > -6f)
            {
                transform.Translate(0, 0, -speed);
            }
        }
    }
}
