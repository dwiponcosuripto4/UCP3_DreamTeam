using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComp : MonoBehaviour
{
    private float speed = 3.0f;
    private float range = 5.5f;

    private float startZ;
    // Start is called before the first frame update
    void Start()
    {
        startZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Hitung posisi baru menggunakan sinusoidal untuk bolak-balik
        float newZ = startZ + Mathf.Sin(Time.time * speed) * range;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
    }
}
