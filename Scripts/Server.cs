using UnityEngine;

public class Server : MonoBehaviour
{
    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    private void OnMouseDown()
    {
         m_gc.IncreaseAchievement();
    }
    private void OnMouseUp()
    {
        m_gc.SetLiveState(false);
        Destroy(gameObject);
    }
}
