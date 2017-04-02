﻿using System.Collections;
using UnityEngine;

public class TeleportType : CharacterType{

    bool neutral = true;//check if player can do stuff

    public Attack melee;//the script associated w/ the melee attack
    public Transform rotationTrans;
    public GameObject projectile;//the projectile.

	// Use this for initialization
	void Start()
    {
        //overwrite movespeed and hp here.
        movespeed = 3;
        hp = 4;
        //setting melee
    }

    //Primary attack. A-Teleports.
    override public void Primary()
    {
        StartCoroutine(PrimaryA());
    }

    //secondary attack, melee hit. B
    public override void Secondary()
    {
        StartCoroutine(SecondaryA());
    }

    //thrid attack, the projectile. Y
    public override void Tertiary()
    {
        StartCoroutine(TertiaryA());
    }

    //primary attack: a teleport.
    private IEnumerator PrimaryA()
    {
        if (neutral)
        {
            neutral = false;
            float startup = .1f;
            float invul = .4f;
            float recovery = .2f;
            float distance = 3;

            //using these because going back and forth between rotation and doing trig sounds hard


             LayerMask mask = 1<<8;

            //set up teleport point
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rotationTrans.up, distance, mask);
            if (hit.collider != null)
            {
                distance = Mathf.Abs(hit.point.y - transform.position.y);
            }

            Vector3 futPos = transform.position +rotationTrans.up * distance;

            yield return new WaitForSeconds(startup);
            //remove hitboxes or set invul as true for now.
            yield return new WaitForSeconds(invul);

            //actually teleport
            transform.position = futPos;
            yield return new WaitForSeconds(recovery);

            //you can do other stuff now.
            neutral = true;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    private IEnumerator SecondaryA()
    {
        if (neutral)
        {
            neutral = false;

            float startup = .1f;
            float active = .4f;
            float recovery = .2f;
            yield return new WaitForSeconds(startup);

            //turn hitbox on.
            melee.Activate();
            yield return new WaitForSeconds(active);

            //hitbox off
            melee.Deactivate();
            yield return new WaitForSeconds(recovery);
            neutral = true;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    private IEnumerator TertiaryA()
    {
        if (neutral)
        {
            //get aim dir
            neutral = false;

            float startup = .1f;
            yield return new WaitForSeconds(startup);

            //create projectile and set its position and parents
            GameObject bullet = Instantiate(projectile, transform);
            bullet.transform.eulerAngles = rotationTrans.eulerAngles;
            bullet.transform.SetParent(null);
            neutral = true;
            yield return null;
        }
        else
        {
            yield return null;
        }

    }
}
