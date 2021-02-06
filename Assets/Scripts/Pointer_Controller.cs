using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer_Controller : MonoBehaviour
{
    [SerializeField] GameObject pointer;
    public void Start()
    {
        pointer.SetActive(false);
    }

    public void Activate_Pointer(Vector2 pointer_Position)
    {
        pointer.SetActive(true);
        Move_Pointer(pointer_Position);
    }

    public void Move_Pointer(Vector2 pointer_Position)
    {
        pointer.transform.position = new Vector3(pointer_Position.x, pointer_Position.y, 0);
    }

    public void Deactivate_Pointer()
    {
        pointer.SetActive(false);
    }
}
