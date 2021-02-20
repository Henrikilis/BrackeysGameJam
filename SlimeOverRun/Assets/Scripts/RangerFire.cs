using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerFire : MonoBehaviour
{
    public bool attacking;
    public GameObject arrow;
    public GameObject mainObject;
    public GameObject arrowSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //hp = FindObjectOfType<hpbar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && mainObject.GetComponent<Ranger>().dead == false)
        {
            mainObject.GetComponent<Ranger>().anim.SetBool("Attacking", true);
            attacking = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && mainObject.GetComponent<Ranger>().dead == false)
        {
            mainObject.GetComponent<Ranger>().anim.SetBool("Attacking", false);
            attacking = false;
        }
    }

    public void ShootArrow()
    {
        if (mainObject.GetComponent<Ranger>().dead == false)
        {
            Instantiate(arrow, arrowSpawner.transform.position, arrowSpawner.transform.rotation);
        }
    }
}
