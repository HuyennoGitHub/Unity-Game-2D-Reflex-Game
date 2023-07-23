using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    private Vector3 m_mousePos;
    private Vector2 m_different;
    private Vector3 m_startPos;

    GameController m_gc;
    bool isDraggable = true;

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_startPos = transform.position;
    }
    private void Update()
    {
        if(m_gc.isGameover()) 
            Destroy(gameObject);
    }
    private void GetMousePos()
    {
        m_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        isDraggable = true;
        GetMousePos();
        m_different = (Vector2)(m_mousePos - transform.position);
    }
    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            GetMousePos();
            transform.position =(Vector2) m_mousePos - m_different;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            m_gc.IncreaseAchievement();
            m_gc.SetLiveState(false);
            m_gc.SetRoadState(false);
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerExit2D()
    {
        this.transform.localPosition = m_startPos;
        isDraggable = false;
    }
    
}
