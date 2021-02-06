using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_UI_Controller : MonoBehaviour
{
    [SerializeField] GameObject in_Game_UI;
    [SerializeField] GameObject in_Pause_UI;

    public void Pause_Button_Press()
    {
        // TODO: Stop game
        in_Game_UI.SetActive(false);
        in_Pause_UI.SetActive(true);
    }
}
