using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{

    public AudioSource ads;
    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        ads.Play();
        nextLevel();
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
