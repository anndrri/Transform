using UnityEngine;

public class Runners : MonoBehaviour
{
    public Transform[] runners;
    public float speed;
    public int n;
    public float passDistance;
    public float ll;
    // Start is called before the first frame update
    void Start()
    {
        ll = runners.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (n < runners.Length-1)
        {
            runners[n].transform.LookAt(runners[n + 1]);
            runners[n].transform.position = Vector3.MoveTowards(runners[n].position, runners[n + 1].position, Time.deltaTime * speed);
            if (Vector3.Distance(runners[n].position, runners[n + 1].position) <= passDistance)
            {
                n++;
            }
        }
        else 
        {
            if (Vector3.Distance(runners[n].position, runners[0].position) <= passDistance)
            {
                n = 0;
            }
            runners[n].transform.LookAt(runners[0]);
            runners[n].transform.position = Vector3.MoveTowards(runners[n].position, runners[0].position, Time.deltaTime * speed);
        }
    }
}
