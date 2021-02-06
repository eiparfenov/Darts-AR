using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class In_Pause_UI_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject in_Game_UI;
    [SerializeField] GameObject in_Pause_UI;

    public void Resume_Button_Press()
    {
        // TODO: Start game
        in_Game_UI.SetActive(true);
        in_Pause_UI.SetActive(false);
    }
    public void Restart_Button_Press()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Main_Menu_Button_Press()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
