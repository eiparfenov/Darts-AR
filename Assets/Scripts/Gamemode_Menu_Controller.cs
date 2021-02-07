using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemode_Menu_Controller : MonoBehaviour
{
    public static int max_Score = 301;
    public static bool play_With_AI;

    [SerializeField] GameObject difficulty_Menu;
    [SerializeField] GameObject gamemode_Menu;

    public void AI_301_Button_Press()
    {
        max_Score = 301;
        play_With_AI = true;
        Start_Game();
    }
    public void AI_501_Button_Press()
    {
        max_Score = 501;
        play_With_AI = true;
        Start_Game();
    }
    public void Back_Button_Press()
    {
        difficulty_Menu.SetActive(true);
        gamemode_Menu.SetActive(false);
    }

    private void Start_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
