using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Quiz quiz;
    [SerializeField] private EndScreen endScreen;

    void Start()
    {
        if (quiz != null)
        {
            quiz.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Quiz is null in Start method.");
        }

        if (endScreen != null)
        {
            endScreen.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("EndScreen is null in Start method.");
        }
    }

    void Update()
    {
        if (quiz != null && quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);

            if (endScreen != null)
            {
                endScreen.gameObject.SetActive(true);
                // endScreen.FinalScore();
            }
            else
            {
                Debug.LogError("EndScreen is null in Update method.");
            }
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
