using UnityEngine;

public class Bomb : MonoBehaviour
{
    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float radius = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Explode();
        }
    }

    void Explode() 
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null) 
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0) 
                {
                    float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce); //so the diraction with the multiplayed by the wanted force 
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
