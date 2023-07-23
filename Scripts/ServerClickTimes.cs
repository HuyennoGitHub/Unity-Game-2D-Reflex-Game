using UnityEngine;

public class ServerClickTimes : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(-0.1f,-0.1f,0f);

    GameController m_gc;
    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }
    private void OnMouseDown()
    { 
        transform.localScale += scaleChange;
    }
    private void OnMouseUp()
    {
        if (transform.localScale.x < 0.5f)
        {
            m_gc.IncreaseAchievement();
            m_gc.SetLiveState(false);
            Destroy(gameObject);
        }
    }
}
