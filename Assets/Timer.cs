using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool isAnsweringQuestion = false;
    float timerValue;
    public float fillFraction;
    public bool loadNextQuestion;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }


    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timerValue>0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
           else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }

        else
        {
            if(timerValue>0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
       
    }
}
