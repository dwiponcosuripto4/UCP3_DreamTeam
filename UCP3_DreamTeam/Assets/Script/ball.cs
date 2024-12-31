using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 10.0f; 
    // Start is called before the first frame update
    void Start()
    {
        float[] rayy = new float[2];
        rayy[0] = -6.0f;
        rayy[1] = 6.0f;
        int x = (int)Random.Range(0,1.4f);
        int y = (int)Random.Range(-4.5f,4.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(x,0,y) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
