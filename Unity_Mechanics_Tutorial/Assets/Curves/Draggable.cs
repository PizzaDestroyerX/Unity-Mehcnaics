using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    private void OnMouseDown() => difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    private void OnMouseDrag() => transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    
}
