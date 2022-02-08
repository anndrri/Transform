using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public int n = 2;
    public int a;
    public int b;
    public Camera mainCamera;
    public Vector3[] target;
    public Vector3[] targetTemp;
    public LayerMask layerID;
    public Vector3 hit;
    public bool forward = true;
    public bool go;
    public float speed;
    public GameObject ball;
    public Vector3 pointScale;
    public Button btn;
    void Start()
    {
        pointScale = new Vector3(0.25f, 0.25f, 0.25f);
        target = new Vector3[n];
        targetTemp = new Vector3[n];
        targetTemp[0] = transform.position;
        Instantiate(ball, transform.position, Quaternion.identity);
    }
    void Update()
    {
        if (a >= 2)
        {
            btn.interactable = true;
        }
        if (go)
            transform.position = Vector3.MoveTowards(transform.position, target[b], Time.deltaTime * speed);
        if (transform.position == target[b] && b != a - 1 && go && forward == true)
        {
            b++;
            Debug.Log("не смотри");
            transform.LookAt(target[b]);
        }
        else if (transform.position == target[a - 1] && go)
        {
            forward = false;
            b--;
            transform.LookAt(target[b]);
        }
        else if (transform.position == target[b] && b != 0 && go && forward == false)
        {
            b--;
            Debug.Log("сказал же не смотри");
            transform.LookAt(target[b]);
        }
        else if (transform.position == target[0] && go)
        {
            forward = true;
            transform.LookAt(target[b]);
        }
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerID) && a < 6)
            {
                GameObject point = Instantiate(ball, raycastHit.point, Quaternion.identity);
                point.transform.localScale = pointScale;
                pointScale.Scale(new Vector3(1.2f, 1.2f, 1.2f));
                targetTemp[a] = raycastHit.point;
                target = new Vector3[n];
                targetTemp.CopyTo(target, 0);
                n++;
                targetTemp = new Vector3[n];
                target.CopyTo(targetTemp, 0);
                a++;
                Debug.Log(target[0]);
            }
        }
    }
    public void OnClick()
    {
        go = true;
    }
}
