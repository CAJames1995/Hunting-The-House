using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class RiddleScript : MonoBehaviour
{
    [SerializeField] Button skipButton;
    [SerializeField] Button solveButton;

    public TMP_Text riddleText;
    public TMP_InputField answerInput;
    public TMP_Text finalScore;
  

    private Dictionary<string, string> riddles;
    private KeyValuePair<string, string> currentRiddle;
    private int score;

    void Start()
    {
        riddles = LoadRiddlesFromFile("riddles.txt");
        score = 0;

        skipButton.onClick.AddListener(SkipRiddle);
        solveButton.onClick.AddListener(SolveRiddle);

        DisplayRandomRiddle();
    }

    private Dictionary<string, string> LoadRiddlesFromFile(string filename)
    {
        Dictionary<string, string> riddles = new Dictionary<string, string>();
        
        string filePath = Path.Combine(Application.dataPath, "Models", filename);
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('*');
            if (parts.Length == 2)
            {
                riddles.Add(parts[0].Trim(), parts[1].Trim());
            }
        }

        return riddles;
    }

    public void DisplayRandomRiddle()
    {
        if (riddles.Count == 0) return;

        int randomIndex = UnityEngine.Random.Range(0, riddles.Count);
        KeyValuePair<string, string> randomRiddle = riddles.ElementAt(randomIndex);
        currentRiddle = randomRiddle;

        riddleText.text = randomRiddle.Key;
    }

    public void RemoveCurrentRiddle()
    {
        riddles.Remove(currentRiddle.Key);
    }

    public void UpdateScore()
    {
         score++;
        int maxScore = 5;
        finalScore.text = "Score: " + score.ToString() + " / " + maxScore.ToString();
    }

    public void SkipRiddle()
    {
        RemoveCurrentRiddle();
        DisplayRandomRiddle();
    }

    public void SolveRiddle()
    {
        string submittedAnswer = answerInput.text.Trim();
        if (submittedAnswer.Equals(currentRiddle.Value, StringComparison.OrdinalIgnoreCase))
        {
            UpdateScore();
            RemoveCurrentRiddle();
        }
        DisplayRandomRiddle();
        answerInput.text = "";
    }
}

