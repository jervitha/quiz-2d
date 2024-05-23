using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="quiz question" ,fileName="new question")]
public class QuestionSo : ScriptableObject
{
    [TextArea(3,6)]
    [SerializeField] string question="enter your question here";
    [SerializeField] string []answers = new string[4];
    [SerializeField] int correctAnswer;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
    public string GetAnswer(int index)
    {
        return answers[index];
    }
}


/*public class test
{
    QuestionSo questionSo;
    void TestA()
    {
        questionSo.GetQuestion();
        questionSo.GetCorrectAnswer();
        

    }
}*/