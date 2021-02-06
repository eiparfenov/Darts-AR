using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_Menu_Controller : MonoBehaviour
{
    public static string selected_difficulty = "Practice";

    [SerializeField] GameObject main_Menu;
    [SerializeField] GameObject difficulty_Menu;

    public void Back_Button_Press()
    {
        main_Menu.SetActive(true);
        difficulty_Menu.SetActive(false);
    }

    public void Practice_Button_Press()
    {
        selected_difficulty = "Practice";
        Open_Mode_Menu();
    }
    public void Easy_Button_Press()
    {
        selected_difficulty = "Easy";
        Open_Mode_Menu();
    }
    public void Midle_Button_Press()
    {
        selected_difficulty = "Midle";
        Open_Mode_Menu();
    }
    public void Hard_Button_Press()
    {
        selected_difficulty = "Hard";
        Open_Mode_Menu();
    }
    private void Open_Mode_Menu()
    {
        Debug.Log(Difficulty_Menu_Controller.selected_difficulty);
    }
}
