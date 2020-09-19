using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionBox : MonoBehaviour
{
    public Color color;

    static List<CollisionBox> collisionBoxList = new List<CollisionBox>();

    private void OnEnable()
    {
        color = GetComponent<SpriteRenderer>().color;
        collisionBoxList.Add(this);
    }

    private void OnDisable()
    {
        collisionBoxList.Remove(this);
    }

    public static void CheckAll() 
    {
        foreach (CollisionBox box in collisionBoxList) 
        {
            box.DisableCollision(box.color);
        }
    }

    public void DisableCollision(Color color) 
    {
        if (color == GetComponent<SpriteRenderer>().color) 
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
