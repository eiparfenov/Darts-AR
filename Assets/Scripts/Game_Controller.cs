using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] GameObject pointer; // Указатель
    Pointer_Controller pointer_Controller; // Скрипт на указателе

    [SerializeField] GameObject dart_Zero_Position; // Позиция дротика для отображения "в руке"
    Dart_In_Aim_Controller dart_In_Aim_Controller; // Скрипт для управления джойстиком "в руке"

    // Камера (для получения ее координат)
    [SerializeField] GameObject main_Camera;

    // Средняя точка кривой Безье
    [SerializeField] GameObject traectory_Point;  
    
    // Префаб с дротиком
    [SerializeField] GameObject pr_Dart; 

    // Правый скорборд
    [SerializeField] GameObject right_Scoreboard;
    Scoreboard_Controller right_Scoreboard_Controller;

    // Левый скорборд
    [SerializeField] GameObject left_Scoreboard;
    Scoreboard_Controller left_Scoreboard_Controller;

    // Дротики в мишени
    List<GameObject> darts_In_Target = new List<GameObject>();

    // Игрок может совершить бросок
    bool in_Game = true;

    private void Start()
    {
        // Достаем необходимые компаненты
        pointer_Controller = pointer.GetComponent<Pointer_Controller>();
        dart_In_Aim_Controller = dart_Zero_Position.GetComponent<Dart_In_Aim_Controller>();
        right_Scoreboard_Controller = right_Scoreboard.GetComponent<Scoreboard_Controller>();
        // left_Scoreboard_Controller = left_Scoreboard.GetComponent<Scoreboard_Controller>();

    }
    
    // Функции для внешней работы
    public void Aim_Start(Vector2 finger_Position)
    {
        if (Difficulty_Menu_Controller.selected_difficulty == "Practice")
        {
            Practice_Aim_Start(finger_Position);
        }
    }
    public void Aim_Move(Vector2 finger_Position)
    {
        if (Difficulty_Menu_Controller.selected_difficulty == "Practice")
        {
            Practice_Aim_Move(finger_Position);
        }
    }
    public void Aim_Finish(Vector2 finger_Position)
    {
        if(Difficulty_Menu_Controller.selected_difficulty == "Practice")
        {
            Practice_Aim_Finish(finger_Position);
        }
    }

    private void Set_Traectory_Point()
    {
        // Установка дополнительной точки траектори
        Vector3 camera_Position = main_Camera.transform.position;
        Vector3 pointer_Position = pointer.transform.position;
        Vector3 tractory_Point_Position = (camera_Position + pointer_Position) / 2;
        float distance = (camera_Position - pointer_Position).magnitude;
        tractory_Point_Position.y += distance / 20;
        traectory_Point.transform.position = tractory_Point_Position;
    }
    private GameObject Shoot()
    {
        // Бросок
        GameObject shot = Instantiate(pr_Dart);
        shot.GetComponent<Dart_Motion>().Setup(
            dart_Zero_Position.transform.position,
            traectory_Point.transform.position,
            pointer.transform.position
            );
        return shot;
    }

    // Функции для режима практики
    private void Practice_Aim_Start(Vector2 aim_Position)
    {
        if (in_Game)
        {
            // При начеле прецеливания
            pointer_Controller.Activate_Pointer(aim_Position);
            dart_In_Aim_Controller.Activate_Dart(aim_Position / 40);
        }
        else
        {
            // Удалить все дротики
            for (int i = 0; i < darts_In_Target.Count; i++)
            {
                Destroy(darts_In_Target[i]);
            }
            darts_In_Target = new List<GameObject>();
        }
    }
    private void Practice_Aim_Move(Vector2 aim_Position)
    {
        if (in_Game)
        {
            // При прицеливание
            pointer_Controller.Move_Pointer(aim_Position);
            dart_In_Aim_Controller.Move_Dart(aim_Position / 40);
        }
    }
    private void Practice_Aim_Finish(Vector2 finger_Position)
    {
        if (in_Game)
        {
            // При бросании
            pointer_Controller.Deactivate_Pointer();
            dart_In_Aim_Controller.Deactivate_Dart();
            Set_Traectory_Point();
            darts_In_Target.Add(Shoot());
            right_Scoreboard_Controller.Hit(finger_Position, darts_In_Target.Count);

            if (darts_In_Target.Count >= 3)
            {
                in_Game = false;
            }
        }
        else
        {
            in_Game = true;
        }
    }
}
