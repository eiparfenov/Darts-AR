using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Motion : MonoBehaviour
{
    // Точки для построения траектории
    Vector3 Point_1, Point_2, Point_3;

    // Параметр для интеполяции
    float t;

    // Параметр перемещения
    [SerializeField] float speed;

    // Прдыдущая позиция для правильного поворота в полете
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
            // Интерполяция по кривой Безье
            // p(t) = (1 - t)^2 * p0 + 2 * t * (t - 1) * p1 + t^2 * p2
            transform.position = Point_1 * (1 - t) * (1 - t)
                + Point_2 * 2 * t * (1 - t)
                + Point_3 * t * t;
            transform.rotation = Quaternion.LookRotation(-previous_position + transform.position);
        }
    }
}
