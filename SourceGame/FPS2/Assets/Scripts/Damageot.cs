using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageot : MonoBehaviour
{
    private float damage = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
    }
}
