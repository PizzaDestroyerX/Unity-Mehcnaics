using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public GameObject pe_exp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            Instantiate(pe_exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
