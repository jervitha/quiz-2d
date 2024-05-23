using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers=0;
    int questionSeen = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void incrementCorrectAnswer()
    {
        correctAnswers++;
    }
    public int GetQuestionsseen()
    {
        return questionSeen;
    }
    public void incrementQuestionSeen()
    {
        questionSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float) questionSeen * 100);
    }
}
