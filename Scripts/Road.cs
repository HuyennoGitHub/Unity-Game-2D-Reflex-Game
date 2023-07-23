using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject[] roads;
    public GameObject[] StartPoints;
    public GameObject[] EndPoints;

    Vector3 m_startPos;
    Vector3 m_endPos;
    int m_rand;
    float m_randPosX;
    float m_randPosY;
    bool m_directorLeft;
    bool m_directorRight;
    bool m_directorDown;

    GameController m_gc;
   
    private void Start()
    {
        m_gc=FindObjectOfType<GameController>();
        var rand = new System.Random();
        m_rand = rand.Next(4);

        m_startPos = StartPoints[m_rand].transform.position;
        m_endPos = EndPoints[m_rand].transform.position;
    }

    private void Update()
    {
        if (!m_gc.GetLiveState() || m_gc.isGameover())
        {
            Destroy(gameObject);
        }
    }
    public Vector3 GetStartPoint()
    {
        return m_startPos;
    }
    public Vector3 GetEndPoint()
    {
        return m_endPos;
    }
}
