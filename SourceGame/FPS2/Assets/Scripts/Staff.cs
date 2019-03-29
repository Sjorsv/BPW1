using UnityEngine;


public class AbstractStaffBehaviour
{
    public GameObject IceCube;

    public void Awake()
    {

    }
}

public class Staff : MonoBehaviour
{
    public float damage = 10f; // change for damage
    public float range = 100f; // change for range
    public Camera fpsCam;

    public IceStaff IceStafje;
    public EarthStaff EarthStafje;

    public ParticleSystem fireFlash;

    public bool Melt = false;

    private void Awake()
    {
        if (IceStafje == null)
            IceStafje = GameObject.Find("IceStaff").GetComponent<IceStaff>();

        if (EarthStafje == null)
            EarthStafje = GameObject.Find("EarthStaff").GetComponent<EarthStaff>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // function shoot
        }

      

    }

    void Shoot()
    {
        fireFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) // Send out raycast, range
        {
            Target target = hit.transform.GetComponent<Target>();   // Put script Target in variable
            if (target != null) // If target != (is not) null take damage
            {
                if (hit.transform.name == IceStafje.IceCube.name + "(Clone)")
                {
                    Melt = false;

                }
                else Melt = true;
                //target.TakeDamage(damage, Melt);
                target.TakeDamage(damage);
                TakeDamage(target.health, damage, Melt, target.gameObject);
            }
        }

    }

    public void TakeDamage(float health, float amount, bool melt, GameObject destroyThis)
    {
        health -= amount;
        if (health <= 0f)
        {
            if (!melt)
                IceStafje.numberOfIce--;
            if (melt) // ! == false
                EarthStafje.numberOfObjects--;


            Destroy(destroyThis);
        }
    }


    
}
