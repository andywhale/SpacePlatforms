using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour
{
    private Player player;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
    }
}
