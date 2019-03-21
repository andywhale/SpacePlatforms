using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Player player;
    float midPointX;
    float midPointY;
    float speed = 10f;

    bool travelling = false;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        midPointX = Screen.width / 2;
        midPointY = Screen.height / 2;
    }

    void FixedUpdate()
    {
        if (IsTravelling())
        {
            player.MoveForward(speed);
        }
        else
        {
            player.StopPlayer();
        }
    }

    private bool IsTravelling()
    {
        return travelling;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("POINTER-DOWN");
        //Debug.Log(eventData.position.x);
        travelling = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("POINTER-UP");
        //Debug.Log(eventData.position.x);
        travelling = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        travelling = false;
        Vector2 newPosition = eventData.position;
        float ySpeed = (newPosition.y - midPointY) / 100;
        float xSpeed = (newPosition.x - midPointX) / 100;
        player.Steer(new Vector2(ySpeed, xSpeed));

        Debug.Log(newPosition.y);
        Debug.Log(midPointY);

        speed = speed - (Mathf.Abs(xSpeed) + Mathf.Abs(ySpeed)) / 2;
        Debug.Log(speed);
    }
}
