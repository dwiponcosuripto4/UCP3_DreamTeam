using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ball : MonoBehaviour
{
    private float speed = 4.0f;
    public GameObject winnerp1, winnerp2;
    public TMP_Text skorp1_tampil, skorp2_tampil;
    int skorp1 = 0,skorp2 = 0;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Wall p1")
        {
            if (skorp1 <= 30)
            {
                skorp1 = 0;
                winner(winnerp2);
            }
            else
            {
                skorp1 -= 30;
            }
        }
        if(collision.gameObject.name == "Wall p2")
        {
            if (skorp2 <= 30)
            {
                skorp2 = 0;
                winner(winnerp1);
            }
            else
            {
                skorp2 -= 30;
            }
        }
        if(collision.gameObject.name == "player 1")
        {
            skorp1 += 10;
            
        }
        if(collision.gameObject.name == "player 2")
        {
            skorp2 += 10;
        }
        skorp1_tampil.text = skorp1.ToString();
        skorp2_tampil.text = skorp2.ToString();
        GetComponent<AudioSource>().Play();
    }

    public void winner(GameObject obj)
    {
        obj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevelName);
    }
}
