using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Gamemode_Menu_Controller.max_Score);
        Debug.Log(Gamemode_Menu_Controller.play_With_AI);
        Debug.Log(Difficulty_Menu_Controller.selected_difficulty);
    }
}
