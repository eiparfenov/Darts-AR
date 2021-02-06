using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Aim_Controller : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject aim_Panel;
    [SerializeField] GameObject main_Controller;
    Game_Controller game_Controller;

    float panel_Width, panel_Height;
    public void Start()
    {
        panel_Width = aim_Panel.GetComponent<RectTransform>().rect.width;
        panel_Height = aim_Panel.GetComponent<RectTransform>().rect.height;
        game_Controller = main_Controller.GetComponent<Game_Controller>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        game_Controller.Aim_Start(Conver_To_Pointer_Position(eventData.position));
    }

    public void OnDrag(PointerEventData eventData)
    {
        game_Controller.Aim_Move(Conver_To_Pointer_Position(eventData.position));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        game_Controller.Aim_Finish();
    }

    private Vector2 Conver_To_Pointer_Position(Vector2 position)
    {
        float x = position.x;
        float y = position.y;

        x = (x - panel_Width / 2) / 100;
        y = (y - panel_Height / 2) / 100;

        x = Mathf.Clamp(x, -5, 5);
        y = Mathf.Clamp(y, -5, 5);

        return new Vector2(x, y);
    }
}
