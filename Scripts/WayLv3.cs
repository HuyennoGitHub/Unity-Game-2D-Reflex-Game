using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayLv3 : MonoBehaviour
{
    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (m_gc.GetRoadState() == false || m_gc.isGameover())
        {
            Destroy(gameObject);
        }
    }
}
