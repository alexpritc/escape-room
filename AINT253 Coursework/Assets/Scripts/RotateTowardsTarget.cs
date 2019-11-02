using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    public GameObject target;

    private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

    }

    //var rotation = Quaternion.LookRotation(target.position - transform.position);
    //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime* damping);
 }

