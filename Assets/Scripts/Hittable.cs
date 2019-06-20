using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hittable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler {

	void FixedUpdate () {
        GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 6.0f);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " clicked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

}
