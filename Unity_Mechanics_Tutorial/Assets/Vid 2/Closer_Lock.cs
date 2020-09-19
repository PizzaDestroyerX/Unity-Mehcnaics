using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Closer_Lock : MonoBehaviour
{
    [Space]
    public Transform target;
    public RectTransform UI_Canvas;
    [Space]
    public Material m_material;
    [Space]
    public float closest = 1;
    public float furthest = 200;
    public float zoomDuration = 1f;
    [Space]
    public TextMeshProUGUI intractionsText;
    [Space]
    public float textMargin_X = 20;
    public float textMargin_Y = 20;

    Vector2 lockPos;

    private void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    private void OnEnable()
    {
        Lock();
        intractionsText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Lock();
            StartCoroutine(Zoom_On_Object(furthest , closest));
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            DisableAll();
        }
    }

    void Lock() 
    {

        GetComponent<Image>().enabled = true;

        m_material.SetFloat("Vector1_5D41F9FD", furthest); //make the shader at start invisible
        m_material.SetFloat("Vector1_629939DC", UI_Canvas.rect.width);//calculating acording to the width of the canvas
        m_material.SetFloat("Vector1_57E4DFD6", UI_Canvas.rect.height);//calculating acording to the height of the canvas

        //convert the POSITION of the trasnsform to something that we can manipulate
        lockPos = new Vector2(Camera.main.WorldToScreenPoint(target.position).x, Camera.main.WorldToScreenPoint(target.position).y);
        

        //Converting shader position to screen point position, and than set the position of the center of the circle to the center
        //calculated here
        m_material.SetFloat("Vector1_903261F8", UI_Canvas.rect.width / 2 - lockPos.x);
        m_material.SetFloat("Vector1_42811529", UI_Canvas.rect.height / 2 - lockPos.y);

        //set text position to be above a certien pixel amount, this is where the massage is gonna be placed
        intractionsText.transform.position = new Vector2(lockPos.x + textMargin_X,lockPos.y + textMargin_Y);
    }

    //simple lerp to zoom on the object
    IEnumerator Zoom_On_Object(float startFloat, float endFloat) 
    {
        float i = 0;
        while (i < 1) 
        {
            m_material.SetFloat("Vector1_5D41F9FD", Mathf.Lerp(startFloat, endFloat, Mathf.SmoothStep(0, 1, i)));
            i += Time.deltaTime / zoomDuration;
            yield return null;
        }

        //after we zoomed it, we can activate the text
        if (startFloat == furthest)
        {
            intractionsText.gameObject.SetActive(true);
        }
        else 
        {
            GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
    }

    void DisableAll() 
    {
        StartCoroutine(Zoom_On_Object(closest, furthest));
        intractionsText.gameObject.SetActive(false);
    }
}
