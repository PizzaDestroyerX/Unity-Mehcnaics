using UnityEngine;

public class Lanch : MonoBehaviour
{
    [SerializeField] private float launchForce = 2f;
    Rigidbody2D m_Rigidbody;

    Vector2 firstPos, lastPos;

    void Start() => m_Rigidbody = GetComponent<Rigidbody2D>();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LaunchBall();
        }
    }

    void LaunchBall() 
    {
        m_Rigidbody.AddForce((firstPos - lastPos) * launchForce);
    }
}
