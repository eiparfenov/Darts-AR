using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    Pointer_Controller pointer_Controller;

    private void Start()
    {
        pointer_Controller = pointer.GetComponent<Pointer_Controller>();
    }

    public void Aim_Start(Vector2 finger_Position)
    {
        pointer_Controller.Activate_Pointer(finger_Position);
    }

    public void Aim_Move(Vector2 finger_Position)
    {
        pointer_Controller.Move_Pointer(finger_Position);
    }

    public void Aim_Finish()
    {
        pointer_Controller.Deactivate_Pointer();
    }
}
