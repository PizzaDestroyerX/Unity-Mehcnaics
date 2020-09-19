using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100; 
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;

    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    void Start()
    {
        Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * 1000);
    }

    void Update()
    {
        ShootLaser();
    }

    void ShootLaser() 
    {
        Debug.DrawRay(m_transform.position, m_transform.rotation.eulerAngles, Color.red);
        if (Physics2D.Raycast((Vector2)m_transform.position, (Vector2)transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast((Vector2)m_transform.position, (Vector2)transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point); 

            //Here do whatever
        }
        else 
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector3 startLaserPoint, Vector3 endLaserPoint) 
    {
        m_lineRenderer.SetPosition(0, startLaserPoint);
        m_lineRenderer.SetPosition(1, endLaserPoint);
    }
}
