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
    public TMP_Text riddleCount;
  

    private Dictionary<string, string> riddles;
    private KeyValuePair<string, string> currentRiddle;
    private int score, count;

    void Start()
    {
        riddles = LoadRiddlesFromFile("riddles.txt");
        score = 0;
        //count = 1;
        riddleCount.text = "";

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
        //riddleCount.text = count + "/5";
    }

    public void RemoveCurrentRiddle()
    {
        riddles.Remove(currentRiddle.Key);
    }

    public void UpdateScore()
    {
        score++;
        finalScore.text = score.ToString();

        //int maxScore = 5;
        //finalScore.text = "Score: " + score.ToString() + " / " + maxScore.ToString();
    }

    public void SkipRiddle()
    {
        RemoveCurrentRiddle();
        DisplayRandomRiddle();
        riddleCount.text = "Too hard? Try this one.";

    }

    public void SolveRiddle()
    {
        string submittedAnswer = answerInput.text.Trim();

        //if (submittedAnswer == "")
        //{
        //    riddleCount.text = "Try entering a guess first.";
        //    return;
        //}

        if (submittedAnswer.Equals(currentRiddle.Value, StringComparison.OrdinalIgnoreCase))
        {
            riddleCount.text = "Nice Job!";
            UpdateScore();
            RemoveCurrentRiddle();
        }
        else 
        {
            riddleCount.text = "That's not it..";
        }

        DisplayRandomRiddle();
        answerInput.text = "";
    }

}

