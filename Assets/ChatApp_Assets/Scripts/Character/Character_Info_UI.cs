using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Info_UI : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.LookAt(target.transform);
    }
}
