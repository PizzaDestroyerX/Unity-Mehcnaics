using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanchBall : MonoBehaviour
{
    [SerializeField] private float launchForce = 5f;
    public TextMeshProUGUI numberOfJumps;
    public int lanchNumber;

    Animator m_animator;
    Rigidbody2D m_rigidbody;
    Vector2 startPos, finalPos;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        numberOfJumps.text = lanchNumber.ToString();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lanchNumber > 0) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                finalPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                if (startPos != finalPos) 
                {
                    m_rigidbody.isKinematic = false;
                    m_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    m_rigidbody.AddForce(-(finalPos - startPos) * launchForce);
                    lanchNumber--;
                    UpdateText();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground")) 
        {
            lanchNumber = 1;
            UpdateText();
        }

        if (collision.transform.CompareTag("Destroy")) 
        {
            //m_animator.Play("ChangeSizeAndColor");
            spriteRenderer.color = collision.transform.GetComponent<SpriteRenderer>().color;
            CollisionBox.CheckAll();
            lanchNumber = 1;
            UpdateText();

        }
        
    }

    public void UpdateText() 
    {
        numberOfJumps.text = lanchNumber.ToString();
    }
}
