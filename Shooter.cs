using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject FireCucumber, gun;
    AttakerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_TILE_NAME = "projectile";
    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreatePrijectileMetod();
    }

    private void CreatePrijectileMetod()
    {
        projectileParent = GameObject.Find(PROJECTILE_TILE_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_TILE_NAME);
        }
    }

    private void Update()
    {
        if (IsAttakainLane())
        {
            animator.SetBool("IsAttaking", true);
        }
        else
        {
            animator.SetBool("IsAttaking", false);
        }
    }
    private void SetLaneSpawner()
    {
        AttakerSpawner[] spawners = FindObjectsOfType<AttakerSpawner>();

        foreach(AttakerSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                <=Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttakainLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Fire()
    {
       GameObject newProjectile  = 
            Instantiate(FireCucumber, gun.transform.position,gun.transform.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
