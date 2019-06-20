using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Asteroid : Hittable {

    [SerializeField] GameObject hitState;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 6.0f);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " planet clicked");
        Instantiate(hitState, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
