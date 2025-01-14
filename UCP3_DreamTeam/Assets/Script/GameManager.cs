using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    public TMP_Text bestScorePlayer1Text;
    public TMP_Text bestScorePlayer2Text;
    public TMP_Text soloScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (player1ScoreText != null && player2ScoreText != null)
        {
            player1ScoreText.text = "PLAYER 1: " + ScoreManager.Instance.win1Score.ToString();
            player2ScoreText.text = "PLAYER 2: " + ScoreManager.Instance.win2Score.ToString();
        }

        if (bestScorePlayer1Text != null && bestScorePlayer2Text != null)
        {
            bestScorePlayer1Text.text = "PLAYER 1: " + ScoreManager.Instance.bestScore1.ToString();
            bestScorePlayer2Text.text = "PLAYER 2: " + ScoreManager.Instance.bestScore2.ToString();
        }
        if (soloScoreText != null)
        {
            soloScoreText.text = "BEST SOLO: " + ScoreManager.Instance.bestSoloScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        ScoreManager.Instance.LoadScore();

        player1ScoreText.text = "PLAYER 1: " + ScoreManager.Instance.win1Score.ToString();
        player2ScoreText.text = "PLAYER 2: " + ScoreManager.Instance.win2Score.ToString();

        bestScorePlayer1Text.text = "PLAYER 1: " + ScoreManager.Instance.bestScore1.ToString();
        bestScorePlayer2Text.text = "PLAYER 2: " + ScoreManager.Instance.bestScore2.ToString();

        if (soloScoreText != null)
        {
            soloScoreText.text = "BEST SOLO: " + ScoreManager.Instance.bestSoloScore.ToString();
        }
        Debug.Log("Game berhasil dimuat!");
    }

    public void SaveGame()
    {
        ScoreManager.Instance.SaveScore();
        Debug.Log("Game berhasil disimpan!");
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
