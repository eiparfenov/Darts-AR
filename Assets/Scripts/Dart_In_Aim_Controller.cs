using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_In_Aim_Controller : MonoBehaviour
{
    [SerializeField] GameObject dart;

    public void Activate_Dart(Vector2 finger_Position)
    {
        dart.SetActive(true);
        Vector3 position = new Vector3(finger_Position.x, finger_Position.y, 0);
        dart.transform.localPosition = position;
    }

    public void Move_Dart(Vector2 finger_Position)
    {
        Vector3 position = new Vector3(finger_Position.x, finger_Position.y, 0);
        dart.transform.localPosition = position;
    }

    public void Deactivate_Dart()
    {
        dart.SetActive(false);
    }
}
