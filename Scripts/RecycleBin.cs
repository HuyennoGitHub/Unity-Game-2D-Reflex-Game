using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBin : MonoBehaviour
{
    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        if (m_gc.isGameover())
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
