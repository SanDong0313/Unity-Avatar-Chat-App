using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickCamera : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position, 0.1f);
    }
}
