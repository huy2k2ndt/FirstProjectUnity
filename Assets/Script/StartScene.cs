using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
