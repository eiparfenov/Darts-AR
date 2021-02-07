using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    Pointer_Controller pointer_Controller;

    [SerializeField] GameObject dart_Zero_Position;
    Dart_In_Aim_Controller dart_In_Aim_Controller;

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
    }
}
