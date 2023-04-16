using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void fllowPlayer()
    {
        if (!player) return;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        fllowPlayer();
    }
}
