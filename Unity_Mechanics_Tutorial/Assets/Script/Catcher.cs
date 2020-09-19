using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public static Transform Player;
    public float timeToCenter = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null) 
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Player.GetComponent<Rigidbody2D>() != null)
            {
                Player.GetComponent<Rigidbody2D>().isKinematic = true;
                Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(SendToMiddle(Player));
            }
        }
    }

    IEnumerator SendToMiddle(Transform objectToSend) 
    {
        Vector2 startPos = objectToSend.position;
        float i = 0;
        while (i < 1) 
        {
            Player.transform.position = Vector2.Lerp(startPos, transform.position, Mathf.SmoothStep(0, 1, i));
            i += Time.deltaTime / timeToCenter;
            yield return null;
        }
        Player.GetComponent<LanchBall>().lanchNumber++;
        Player.GetComponent<LanchBall>().UpdateText();
    }

    
}
