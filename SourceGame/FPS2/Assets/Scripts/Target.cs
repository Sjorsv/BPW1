using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private EarthStaff earthStaff;
    private IceStaff iceStaff;

    private void Awake()
    {
        //earthStaff = GameObject.Find("StaffEarth").GetComponent<EarthStaff>();
        //iceStaff = GameObject.Find("StaffIce").GetComponent<IceStaff>();
    }

    private void Start()
    {
       
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        /*if (health <= 0f)
        {
            Die(melt);
        }*/
    }

    void Die(bool melt)
    {

        if (!melt)
            iceStaff.numberOfIce--;
        if (melt) // ! == false
            earthStaff.numberOfObjects--;


        Destroy(gameObject);

        //if Component.GetComponent < GameObject > {
        //    private int earthStaff numberOfObjects -= 1;
        //}
    }

    public void Teller()
    {
          int count =  earthStaff.numberOfObjects -= 1;
    }

    //progress if earthcount tag = ground destroy gameobject.time
    //void EarthCount()
    //{
    //    if 
    //}
}