using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed = 4;
    public float bullet_duration = 4;

    Rigidbody2D bullet_rigidbody;

    private void Awake()
    {
        bullet_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("DestoryBullet", bullet_duration);
    }

    private void Update()
    {
        bullet_rigidbody.MovePosition(transform.position + transform.right * bullet_speed);
    }

    void DestoryBullet() 
    {
        Destroy(gameObject);
    }
}
