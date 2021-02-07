using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    Pointer_Controller pointer_Controller;

    [SerializeField] GameObject dart_Zero_Position;
    Dart_In_Aim_Controller dart_In_Aim_Controller;

    [SerializeField] GameObject main_Camera;
    [SerializeField] GameObject traectory_Point;

    private void Start()
    {
        pointer_Controller = pointer.GetComponent<Pointer_Controller>();
        dart_In_Aim_Controller = dart_Zero_Position.GetComponent<Dart_In_Aim_Controller>();
    }

    public void Aim_Start(Vector2 finger_Position)
    {
        pointer_Controller.Activate_Pointer(finger_Position);
        dart_In_Aim_Controller.Activate_Dart(finger_Position / 40);
    }

    public void Aim_Move(Vector2 finger_Position)
    {
        pointer_Controller.Move_Pointer(finger_Position);
        dart_In_Aim_Controller.Move_Dart(finger_Position / 40);
    }

    public void Aim_Finish()
    {
        pointer_Controller.Deactivate_Pointer();
        dart_In_Aim_Controller.Deactivate_Dart();
        Set_Traectory_Point();
    }

    private void Set_Traectory_Point()
    {
        Vector3 camera_Position = main_Camera.transform.position;
        Vector3 pointer_Position = pointer.transform.position;
        Vector3 tractory_Point_Position = (camera_Position + pointer_Position) / 2;
        float distance = (camera_Position - pointer_Position).magnitude;
        tractory_Point_Position.y += distance / 20;
        traectory_Point.transform.position = tractory_Point_Position;
    }
}
