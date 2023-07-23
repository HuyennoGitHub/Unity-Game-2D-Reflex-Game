using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject server;
    public GameObject serverClickTimes;
    public GameObject serverDrag;
    public GameObject RecycleBin;
    public GameObject miner;
    public GameObject treasure;
    public GameObject[] roads;

    public int countDownTime;

    int countDown = 5;
    int m_downTime;
    int m_achievement;
    bool m_isGameover;
    bool m_sLive;
    float m_timed;
    float m_average;
    Vector2 m_startPos;
    Vector2 m_endPos;
    bool m_roadPlaying;

    UIManager m_ui;

    void Start()
    {
        m_downTime = countDownTime;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_achievement);
        m_ui.SetTimeText(m_downTime);
        CountDown();
    }

    void Update()
    {
        if (countDown < 0)
        {
            if (m_isGameover)
            {
                m_ui.SetTimeText(m_downTime);
                m_ui.SetAchievementText("Achievement: " + m_achievement);
                m_timed = countDownTime - m_downTime;
                m_ui.SetTimedText("Time: " + Math.Round(m_timed, 3) + "s");
                m_average = m_timed / m_achievement;
                m_ui.SetAverageTimeText("Average Time: " + Math.Round((float)m_average, 2) + "s");
                m_ui.SetCommentText(m_average);
                m_ui.ShowGameoverPanel(true);
                return;
            }
            if (!m_sLive)
            {
                SpawnThing();
            }
        }
    }
    public void PlayTimeCountDown()
    {
        if (m_isGameover) return;
        if (m_downTime > 0)
        {
            m_ui.SetTimeText(m_downTime);
            m_downTime--;
            Invoke("PlayTimeCountDown", 1.0f);
        }
        else
        {
            m_ui.SetTimeText(m_downTime);
            SetGameoverState(true);
        }
    }
    public void CountDown()
    {
        if (countDown > 0)
        {
            m_ui.ShowCountDownText(true);
            m_ui.SetCountDownText("" + countDown + "");
            countDown--;
            Invoke("CountDown", 1.0f);
        }
        else
        {
            m_ui.ShowCountDownText(false);
            countDown--;
            PlayTimeCountDown();
        }

    }
    public void SpawnThing()
    {
        float randXpos = Random.Range(-7.25f, 7.3f);
        float randYpos = Random.Range(-3.4f, 2.35f);
        var randSelect = new System.Random();
        int select = randSelect.Next(4);

        Vector2 spawnPos = new Vector2(randXpos, randYpos);

        if (select == 0)
        {
            if (server)
            {
                Instantiate(server, spawnPos, Quaternion.identity);
                SetLiveState(true);
            }
        }
        else if (select == 1)
        {
            if (serverClickTimes)
            {
                float randScale = Random.Range(0.6f, 1.25f);
                serverClickTimes.transform.localScale.Set(randScale, randScale, 0);
                Instantiate(serverClickTimes, spawnPos, Quaternion.identity);
                SetLiveState(true);
            }
        }
        else if (select == 2)
        {
            if (RecycleBin)
            {
                float randXPosRecycle = Random.Range(-7f, 7f);
                float randYPosRecycle = Random.Range(-3f, 2f);
                Vector2 binPos = new Vector2(randXPosRecycle, randYPosRecycle);

                Instantiate(RecycleBin, binPos, Quaternion.identity);
            }
            if (serverDrag)
            {
                Instantiate(serverDrag, spawnPos, Quaternion.identity);
                SetLiveState(true);
            }
        }
        else if (select == 3)
        {
            var rand2th = new System.Random();
            int check = rand2th.Next(roads.Length);
            SpawnLv3(roads[check]);
        }
    }

    public void SpawnLv3(GameObject way)
    {
        Instantiate(way);
        SetRoadState(true);
        m_startPos = way.transform.GetChild(0).position;
        m_endPos = way.transform.GetChild(1).position;
       
        Instantiate(miner, m_startPos, Quaternion.identity);
        Instantiate(treasure, m_endPos, Quaternion.identity);
        SetLiveState(true);
    }
    public Vector2 GetStartPos()
    {
        return m_startPos;
    }
    public Vector2 GetEndPos()
    {
        return m_endPos;
    }

    public void SetLiveState(bool state)
        {
            m_sLive = state;
        }
    public bool GetLiveState()
    {
        return m_sLive;
    }

    public void SetAchievement(int value)
    {
        m_achievement = value;
    }

    public int GetAchievement()
    {
        return m_achievement;
    }
    public void IncreaseAchievement()
    {
        m_achievement++;
        m_ui.SetScoreText("Score: " + m_achievement);
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public bool isGameover()
    {
        return m_isGameover;
    }
    public void SetRoadState(bool state)
    {
        m_roadPlaying = state;
    }
    public bool GetRoadState()
    {
        return m_roadPlaying;
    }
    public void Replay()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
