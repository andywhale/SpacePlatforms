using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ship : Hittable
{
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 8.0f);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " ship clicked");
        GetComponent<Rigidbody>().AddExplosionForce(200f, eventData.pointerPressRaycast.worldPosition, 2f);
    }
}
