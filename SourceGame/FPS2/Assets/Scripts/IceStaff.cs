using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStaff : MonoBehaviour
{
    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public float range = 100f;
    public float lifetime = 2f;
    public int numberOfIce = 0;
    public GameObject IceCube;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // getbutton = vasthouden
        {
            ShootIce(Input.mousePosition);
        }
        
    }

    public void ShootIce(Vector2 mousePosition)
    {

        if (numberOfIce < 5)
        {
            RaycastHit hit = RayFromCameraIce(mousePosition, 1000.0f);
            Instantiate(IceCube, hit.point, Quaternion.identity);
            numberOfIce = numberOfIce + 1;
            
        }

        else
        {
            // spawn text max cubes reached
        }

    }

    //public void Destroyijs()
    //{
    //    if (numberOfIce > 1 /* || gameObject.tag == "ice"*/)
    //    {
    //        //yield return new lifetime
    //        Destroy(GameObject.FindWithTag("ice"), lifetime);
            
    //        //Destroy(gameObject, lifetime);
    //    }
    //    if (numberOfIce >= 5)
    //    {
    //        numberOfIce = number
    //    }
    //}

        public void Destroyijs ()
    {
        if (gameObject.tag == "ice")
        {
            Destroy(gameObject,lifetime);
        }
    }

public RaycastHit RayFromCameraIce(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}