using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStaff : MonoBehaviour
{
    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public float range = 100f;
    public int numberOfObjects = 0;
    public GameObject SpawnCube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootEarth(Input.mousePosition);
        }
    }

    public void ShootEarth(Vector2 mousePosition)
    {
        
        if (numberOfObjects < 5) {  // max 5 cubes
            RaycastHit hit = RayFromCamera(mousePosition, 10f); // send raycast
             // checken of de raycast iets raakt binnen de raylength > 10f = 10f
            Instantiate(SpawnCube, hit.point + Vector3.up, Quaternion.identity); // create cube
            numberOfObjects = numberOfObjects + 1; // counts float until 5
        //if (GetComponent<Target> { 
        //    destroy
        //        number of objects =-1
        //        }

        }
        else {
           // spawn text max cubes reached
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

//    void Update ()
//    {
//        // telling my ray variable that the ray will go from the center of my main camera to my mouse (This will give me a direction)
//        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

//        // here I ask : if myRay hits something, store all the info you can find in the raycasthit varible.
//        if (Physics.Raycast(myRay, out hit))
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                // instatiate a prefab on the position where the ray hits the floor.
                
//               Instantiate(objectToinstantiate, hit.point, Quaternion.identity);

//                // debugs the vector3 of the position where I clicked
//                Debug.Log(hit.point);

//            }
//        }
//    }


//}