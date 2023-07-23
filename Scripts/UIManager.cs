using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    
    public GameObject GameoverPanel;
    public Text AchievementText;
    public Text TimeText;
    public Text AverageTimeText;
    public Text CommentText;
    public Text CountDownText;
    public GameObject CountDownPanel;

    public void SetCountDownText(string text)
    {
        if (CountDownText)
        {
            CountDownText.text = text;
        }
    }
    public void SetAchievementText(string text)
    {
        if (AchievementText)
        {
            AchievementText.text = text;
        }
    }
    public void SetTimedText(string text)
    {
        if (TimeText)
        {
            TimeText.text = text;
        }
    }
    public void SetAverageTimeText(string text)
    {
        if (AverageTimeText)
        {
            AverageTimeText.text = text;
        }
    }
    public void SetCommentText(float time)
    {
        if (CommentText)
        {
            if (time < 0.5f)
            {
                CommentText.text = "Awesome!";
            }
            else if (time < 1.2f)
            {
                CommentText.text = "Good job!";
            }
            else if (time < 1.8f)
            {
                CommentText.text = "You can do better!";
            }
            else
            {
                CommentText.text = "You're too slow.";
            }

        }
    }

    public void SetScoreText(string text)
    {
        if (scoreText)
        {
            scoreText.text = text;
        }
    }
    public void SetTimeText(int time)
    {
        TimeSpan timespan = TimeSpan.FromSeconds(time);
        timeText.text = timespan.Minutes + " : " + timespan.Seconds;
    }
 
    public void ShowGameoverPanel(bool isShow)
    {
        if (GameoverPanel)
        {
            GameoverPanel.SetActive(isShow);
        }
    }
    public void ShowCountDownText(bool isShow)
    {
        if (CountDownPanel)
        {
            CountDownPanel.SetActive(isShow);
        }
    }
}
