using UnityEngine;
public class ServerDrag : MonoBehaviour
{
    private Vector3 m_mousePos;
    private Vector2 m_different;

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
    private void GetMousePos()
    {
        m_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        GetMousePos();
        m_different = (Vector2) (m_mousePos-transform.position);
        
    }
    private void OnMouseDrag()
    {
        GetMousePos();
        transform.position = (Vector2)m_mousePos - m_different;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            m_gc.IncreaseAchievement();
            m_gc.SetLiveState(false);
            Destroy(gameObject);
        }
    }
}
