using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Mode : MonoBehaviour
{
    public void OnMoveModeChange()
    {
        if(JoyStickCharacter.walk_flag)
        {
            JoyStickCharacter.walk_flag = false;
        }
        else
        {
            JoyStickCharacter.walk_flag = true;
        }
    }
}
