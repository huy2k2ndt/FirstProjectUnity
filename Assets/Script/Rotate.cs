using UnityEngine;
public class Rotate : MonoBehaviour
{
    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
