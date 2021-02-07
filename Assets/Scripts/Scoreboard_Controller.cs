using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard_Controller : MonoBehaviour
{
    [SerializeField] string text;
    int total_Score;
    [SerializeField] float target_Radius;

    public bool Hit(Vector2 hit_Position)
    {
        Points(hit_Position);
        return false;
    }

    private int Points(Vector2 hit_Position)
    {
        float r = hit_Position.magnitude; // Растояние до мишени
        Quaternion q = Quaternion.FromToRotation(
            new Vector3(
                hit_Position.x,
                hit_Position.y,
                0
                ),
            new Vector3(0, 0, 0));
        Debug.Log(q);
        Debug.Log(r);
        return 0;
    }
}
