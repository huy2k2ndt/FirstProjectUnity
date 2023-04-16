using UnityEngine;

public class FllowWayPoint : MonoBehaviour
{
    public GameObject[] wayPoints;
    public int curIdx = 0;
    public float speed = 10f;
    // Start is called before the first frame update
    public void updateWayPoint()
    {
        GameObject curPoint = wayPoints[curIdx];
        float dis = Vector2.Distance(transform.position, curPoint.transform.position);
        if (dis < .1f)
        {
            ++curIdx;
            if (curIdx >= wayPoints.Length) curIdx = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[curIdx].transform.position, Time.deltaTime * speed);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateWayPoint();
    }
}
