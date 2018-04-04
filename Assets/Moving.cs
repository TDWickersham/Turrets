using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour //idamageable
{

    public NavMeshAgent nav;
    public GameObject target;
    public int currentHealth;
    public int Maxhealth;
    float distance;
    // Use this for initialization
    void Start()
    {
        currentHealth = Maxhealth;
        nav = GetComponent<NavMeshAgent>();
    }

    public bool editor;
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (editor)
        {
            editor = false;
            takedamage(2);
        }
        nav.destination = target.transform.position;
        die();
    }
    public void takedamage(int damagetaken)
    {
        currentHealth -= damagetaken;
        die();
    }
    public void die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if(distance <= 10)
        {
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    idamageable damage = other.gameObject.GetComponent<idamageable>();
    //    if (damage != null)
    //    {
    //        damage.takedamage(attackDamage);
    //    }
    //}
}
