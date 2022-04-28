using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickCharacter : MonoBehaviour 
{
    public static bool walk_flag = true;
    public static bool angle_clockwise;
    public static float angle;
    public static bool move_flag = false;
    public static float delta_speed;
    public float delta_angle = 45;
    public float speed = 0.3f;

	void Start () {
		
	}

	void Update () 
    {
        if(move_flag)
        {
            if(walk_flag)
            {
                transform.Translate(0,0,speed * delta_speed);
            }
            else
            {
                transform.Translate(0,0,speed * delta_speed * 4);
            }
            
        }

        if (angle_clockwise == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle + delta_angle, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, angle + delta_angle, 0));
        }
	}
}
