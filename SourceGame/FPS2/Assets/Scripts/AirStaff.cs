using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStaff : MonoBehaviour
{
    public float thrust;
    public Rigidbody rbair;

    void Start()
    {
        rbair = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Duwen();
        }
    }


    void Duwen()
    {
        // send raycast , als raycast komt op object dat gewuwd mag worden. force erbij
        RaycastHit hit = RayFromCamera(Input.mousePosition, 1000.0f);
        if (hit.transform.gameObject.tag == "Pushable")
        {
            Rigidbody hitRB = hit.transform.gameObject.GetComponent<Rigidbody>();
            // var hitRB = hit.transform.gameObject.GetComponent<Rigidbody>();
            hitRB.isKinematic = false;
            hitRB.AddRelativeForce(hit.transform.forward * thrust * 2);
            
            // pak het object dat de raycast raakt en pak hier de rigidbody van, voeg hier force aan toe
        }
        
                
                
            
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}