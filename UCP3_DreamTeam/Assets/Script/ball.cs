using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    private float speed = 7.0f;
    public GameObject winnerp1, winnerp2;
    public TMP_Text skorp1_tampil, skorp2_tampil, skorpComputer_tampil;
    public TMP_Text win1, win2;
    private int skorp1 = 0,skorp2 = 0, skorpComputer = 0;

    public GameObject player1;
    public GameObject player2;
    public GameObject computer;

    // Start is called before the first frame update
    void Start()
    {
        if (ModeManager.Instance.isVsCOM)
        {
            player2.SetActive(false);
            computer.SetActive(true);
        }
        else
        {
            player2.SetActive(true);
            computer.SetActive(false);
        }

        Time.timeScale = 1.0f;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(-1.0f, 1.0f);
        GetComponent<Rigidbody>().velocity = new Vector3(x, 0, z).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        skorp1_tampil.text = skorp1.ToString();
        skorp2_tampil.text = skorp2.ToString();
        if (skorpComputer_tampil != null)
        {
            skorpComputer_tampil.text = skorpComputer.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall p2")
        {
            skorp1 -= 30;
            if (skorp1 <= 0)
            {
                StartCoroutine(CheckWinner(winnerp2, player1));
            }
        }
        else if (collision.gameObject.name == "Wall p1")
        {
            skorp2 -= 30;
            if (skorp2 <= 0)
            {
                StartCoroutine(CheckWinner(winnerp1, player2));
            }
        }
        else if (collision.gameObject.name == "player 1")
        {
            skorp1 += 10;
        }
        else if (collision.gameObject.name == "player 2")
        {
            skorp2 += 10;
        }
        else if (collision.gameObject.name == "computer")
        {
            skorpComputer += 10;
        }

        win1.text = "SCORE:" + skorp1.ToString();
        win2.text = "SCORE:" + skorp2.ToString();
        if (skorpComputer_tampil != null)
        {
            skorpComputer_tampil.text = "SCORE: " + skorpComputer.ToString();
        }
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator CheckWinner(GameObject winnerObj, GameObject losingPlayer)
    {
        if (losingPlayer != null)
        {
            Destroy(losingPlayer);
        }

        yield return new WaitForSeconds(2.0f);

        if (ModeManager.Instance.isVsCOM && winnerObj == winnerp1)
        {
            
            if (skorp1 > ScoreManager.Instance.bestSoloScore)
            {
                ScoreManager.Instance.soloScore = skorp1;
                ScoreManager.Instance.bestSoloScore = skorp1; 
            }
            ScoreManager.Instance.SaveScore(); 
        }

       
        if (!ModeManager.Instance.isVsCOM)
        {
            ScoreManager.Instance.win1Score = skorp1;
            ScoreManager.Instance.win2Score = skorp2;
        }
        winnerObj.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
