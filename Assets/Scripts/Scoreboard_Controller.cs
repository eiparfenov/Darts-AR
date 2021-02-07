using UnityEngine;
using System.Collections;

public class Scoreboard_Controller : MonoBehaviour
{
    string text;
    [SerializeField] int total_Score;
    [SerializeField] float target_Radius;

    [SerializeField] GameObject text_Field;
    TextMesh textMesh;

    public void Start()
    {
        textMesh = text_Field.GetComponent<TextMesh>();
        text = "Scoreboard\n";
        textMesh.text = text;
    }

    public bool Hit(Vector2 hit_Position, int num)
    {
        int points = Points(hit_Position);

        total_Score += points;

        text += points + " ";
        if (num == 3)
            text += "\n";

        StartCoroutine(Print_Text());
        return false;
    }

    // Определение количества очков
    private int Points(Vector2 hit_Position)
    {
        float r = hit_Position.magnitude; // Растояние до центра мишени
        int sp = sector_Points(hit_Position); // Очки за сектор
        float tr = target_Radius / 170; // Один шаг милиметра на мишени.

        Debug.Log(r);
        if (r < 6 * tr)
            return 50;
        else if (r < 32 * tr)
            return 25;
        else if (r < 99 * tr)
            return sp;
        else if (r < 107 * tr)
            return sp * 3;
        else if (r < 162 * tr)
            return sp;
        else if (r < 170 * tr)
            return sp * 2;
        else
            return 0;
    }

    // Определение угла попадания
    private float Angle(Vector2 hit_Position)
    {
        hit_Position = hit_Position.normalized;
        // Debug.Log(Mathf.Acos(hit_Position.x) * Mathf.Rad2Deg + " " + Mathf.Asin(hit_Position.y) * Mathf.Rad2Deg);
        if (hit_Position.x >= 0 && hit_Position.y >= 0)
            return Mathf.Acos(hit_Position.x) * Mathf.Rad2Deg;
        else if (hit_Position.x <= 0 && hit_Position.y >= 0)
            return Mathf.Acos(hit_Position.x) * Mathf.Rad2Deg;
        else if (hit_Position.x <= 0 && hit_Position.y <= 0)
            return 180 + Mathf.Acos(-hit_Position.x) * Mathf.Rad2Deg;
        else
            return 360 - Mathf.Acos(hit_Position.x) * Mathf.Rad2Deg;
    }

    // Определение сектора попадания
    private int sector_Points(Vector2 hit_Position)
    {
        float angle = Angle(hit_Position);
        int[] points = { 6, 13, 4, 18, 1, 20, 5, 12, 9, 14, 11, 8, 16, 7, 19, 3, 17, 2, 15, 10, 6 };
        for (int i = 0; i < points.Length; i++)
            if (angle < 9 + i * 18)
                return points[i];

        return 0;
    }

    private IEnumerator Print_Text()
    {
        yield return new WaitForSeconds(0.5f);
        textMesh.text = text;
    }
}
