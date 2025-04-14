using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireCooldown = 2;
    public float fireRange = 7;
    public float stopDistance = 3;
    
    private Transform target;
    private NavMeshAgent agent;
    private bool canShoot = false;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        InvokeRepeating(nameof(Shoot), 0, fireCooldown);
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        
        if(distance >= stopDistance)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(transform.position);
        
        canShoot = distance <= fireRange;
    }

    void Shoot()
    {
        if(!canShoot) return;
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var direction = target.position - transform.position;
        direction.Normalize();
        bullet.GetComponent<Rigidbody>().velocity = direction * 10;
    }
}
