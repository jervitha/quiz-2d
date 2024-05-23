using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{

    [Header("Questions")]
    QuestionSo currentQuestion;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSo> questions=new List<QuestionSo>();

    [Header("buttons")]
    [SerializeField]GameObject[] answerButton;
    int correctAnswerindex;
    public bool hasAnsweredEarly=true;

    [Header("button color")]
    [SerializeField] Sprite answerDefault;
    [SerializeField] Sprite answerCorrect;

    [Header("timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;


    [Header("slider")]
    [SerializeField] Slider progressBar;
    public bool isComplete;
    
    
    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
   
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonstate(false);
        }
    }


    public  void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonstate(false);
        timer.CancelTimer();
        scoreText.text = "score" + scoreKeeper.CalculateScore() + "%";

        
       
    }

    void DisplayAnswer(int index)
    {
        Image correctImage;
        if (index == currentQuestion.GetCorrectAnswer())
        {
            questionText.text = "correct";
            correctImage = answerButton[index].GetComponent<Image>();
            correctImage.sprite = answerCorrect;
            scoreKeeper.incrementCorrectAnswer();
        }
        else
        {
            correctAnswerindex = currentQuestion.GetCorrectAnswer();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerindex);
            questionText.text = correctAnswer;
            correctImage = answerButton[correctAnswerindex].GetComponent<Image>();
            correctImage.sprite = answerCorrect;
        }
    }



    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonstate(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            progressBar.value++;
            DisplayQuestion();
            scoreKeeper.incrementQuestionSeen();
        }
    }

    void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomIndex];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButton.Length; i++)
        {

            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);

        }
    }

    void SetButtonstate(bool state)
    {
        for(int i=0;i<answerButton.Length;i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for(int i=0;i<answerButton.Length;i++)
        {
            Image button = answerButton[i].GetComponent<Image>();
            button.sprite = answerDefault;
        }
    }

}
