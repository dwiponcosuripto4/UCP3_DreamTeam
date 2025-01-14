using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int win1Score = 0, win2Score = 0;
    public int bestScore1 = 0, bestScore2 = 0;
    public int soloScore = 0;
    public int bestSoloScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    private class SaveData
    {
        public int win1Score;
        public int win2Score;
        public int bestScore1;
        public int bestScore2;
        public int soloScore;
        public int bestSoloScore;
    }

    public void SaveScore()
    {
        if (win1Score > bestScore1)
        {
            bestScore1 = win1Score;
        }
        if (win2Score > bestScore2)
        {
            bestScore2 = win2Score;
        }

        if (soloScore > bestSoloScore)
        {
            bestSoloScore = soloScore;
        }
        SaveData data = new SaveData
        {
            win1Score = win1Score,
            win2Score = win2Score,
            bestScore1 = bestScore1,
            bestScore2 = bestScore2,
            soloScore = soloScore,
            bestSoloScore = bestSoloScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log($"Hasil akhir berhasil disimpan! Best Player 1: {bestScore1}, Best Player 2: {bestScore2}, Best Solo: {bestSoloScore}");
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            win1Score = data.win1Score;
            win2Score = data.win2Score;
            bestScore1 = data.bestScore1;
            bestScore2 = data.bestScore2;
            soloScore = data.soloScore;
            bestSoloScore = data.bestSoloScore;

            Debug.Log($"Hasil akhir berhasil dimuat! Best Player 1: {bestScore1}, Best Player 2: {bestScore2}");
        }
        else
        {
            Debug.Log("Tidak ada file untuk dimuat!");
        }
    }
}
