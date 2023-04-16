using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player") return;
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player") return;
        collision.gameObject.transform.SetParent(null);
    }

}
