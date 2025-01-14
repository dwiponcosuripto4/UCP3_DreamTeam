using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ball : MonoBehaviour
{
    private float speed = 5.0f;
    public GameObject winnerp1, winnerp2;
    public TMP_Text skorp1_tampil, skorp2_tampil;
    private int skorp1 = 0,skorp2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1.0f, 1.0f);
        GetComponent<Rigidbody>().velocity = new Vector3(x, 0, y).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        skorp1_tampil.text = skorp1.ToString();
        skorp2_tampil.text = skorp2.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall p2")
        {
            skorp1 += 10;
            CheckWinner(winnerp1, skorp1);
        }
        // Jika bola menabrak dinding pemain 1 (poin untuk pemain 2)
        else if (collision.gameObject.name == "Wall p1")
        {
            skorp2 += 10;
            CheckWinner(winnerp2, skorp2);
        }
        // Jika bola mengenai pemain 2
        else if (collision.gameObject.name == "player 2")
        {
            skorp1 += 10;
        }
        // Jika bola mengenai pemain 1
        else if (collision.gameObject.name == "player 1")
        {
            skorp2 += 10;
        }

        // Mainkan suara setelah setiap tabrakan
        GetComponent<AudioSource>().Play();
    }

    private void CheckWinner(GameObject winnerObj, int score)
    {
        if (score >= 30)
        {
            winnerObj.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void restart()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevelName);
    }
}
