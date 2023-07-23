using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
