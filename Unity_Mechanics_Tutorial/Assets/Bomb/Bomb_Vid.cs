using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomb_Vid : MonoBehaviour
{
    Collider2D[] inExplosionRadius = null;//2D
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float ExplosionRadius = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Explode();
        }
    }


    void Explode() 
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null) 
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0) //so you will not get NaN error, a nice tip is to not devide by 0 :)
                {
                    float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }
    }

    private void OnDrawGizmos()//draw gizmos
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
