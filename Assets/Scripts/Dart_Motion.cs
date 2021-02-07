using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Motion : MonoBehaviour
{
    // Traectory points
    Vector3 Point_1, Point_2, Point_3;

    //parameter for interpolation
    float t;

    //parameters of motion
    [SerializeField] float speed;

    // for rotation
    Vector3 previous_position;

    public void Setup(Vector3 _Point_1, Vector3 _Point_2, Vector3 _Point_3)
    {
        Point_1 = _Point_1;
        Point_2 = _Point_2;
        Point_3 = _Point_3;
        t = 0;
    }

    public void Update()
    {
        
        if(t <= 1)
        {
            previous_position = transform.position;
            t += Time.deltaTime * speed;
            transform.position = Point_1 * (1 - t) * (1 - t)
                + Point_2 * 2 * t * (1 - t)
                + Point_3 * t * t;
            transform.rotation = Quaternion.LookRotation(-previous_position + transform.position);
        }
    }
}
