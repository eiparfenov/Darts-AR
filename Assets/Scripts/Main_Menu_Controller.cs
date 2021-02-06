using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Controller : MonoBehaviour
{
    [SerializeField] GameObject main_Menu;
    [SerializeField] GameObject difficulty_Menu;

    public void Play_Button_Press()
    {
        main_Menu.SetActive(false);
        difficulty_Menu.SetActive(true);
    }

    public void Quit_Button_Press()
    {
        Application.Quit();
    }
}
