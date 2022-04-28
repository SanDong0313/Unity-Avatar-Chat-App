using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class JoystickCH : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
        private float angle = 0;
        private float preangle = 0;
		private int MovementRange = 80;        
		private string horizontalAxisName = "Garo";
		private string verticalAxisName = "Seoro";
		private Vector2 m_StartPos;
        private Vector2 newPos;
		private bool m_UseX;
		private bool m_UseY; 
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; 
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;
        public Animator anim;

		void OnEnable()
		{
            //CrossPlatformInputManager.GetAxis(horizontalAxisName);
            //CrossPlatformInputManager.GetAxis(verticalAxisName);
			CreateVirtualAxes();
		}
        void Start()
        {
            m_StartPos = transform.position;
            newPos = m_StartPos;
        }

		void CreateVirtualAxes()
		{
            m_UseX = true;
            m_UseY = true;
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}
		public void OnDrag(PointerEventData data)
		{
			if(JoyStickCharacter.walk_flag)
			{
				anim.SetBool("walk_flag",true);
			}
			else
			{
				anim.SetBool("run_flag",true);
			}
            
            JoyStickCharacter.move_flag = true;
			newPos = Vector2.zero;
			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
				newPos.x = delta;
			}
			if (m_UseY)
			{
				int delta = (int)(data.position.y - m_StartPos.y);
				delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
				newPos.y = delta;
			}
            float now_radius = Mathf.Sqrt(newPos.x * newPos.x + newPos.y * newPos.y);
            JoyStickCharacter.delta_speed = now_radius/MovementRange;
            if (MovementRange < now_radius)
            {
                newPos.y = MovementRange * newPos.y / now_radius;
                newPos.x = MovementRange * newPos.x / now_radius;
                transform.position = new Vector2(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y);
            }
            else 
            {
                transform.position = new Vector2(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y);
            }

            JoyStickCharacter.angle = Mathf.Acos(newPos.y / now_radius) * Mathf.Rad2Deg;
            angle = JoyStickCharacter.angle;
            preangle = JoyStickCharacter.angle;
            
            if (newPos.x > 0)
            {
                if (angle > preangle)
                {
                    JoyStickCharacter.angle_clockwise = true;                  
                }                   
                else
                {
                    JoyStickCharacter.angle_clockwise = false;
                }
            }
            else
            {
                if (angle > preangle)
                {
                    JoyStickCharacter.angle_clockwise = false;
                }
                else
                {
                    JoyStickCharacter.angle_clockwise = true;
                }
            }        
		}
		public void OnPointerUp(PointerEventData data)
		{
            JoyStickCharacter.move_flag = false;
			transform.position = m_StartPos;
            newPos = m_StartPos;
            if(JoyStickCharacter.walk_flag)
			{
				anim.SetBool("walk_flag",false);
			}
			else
			{
				anim.SetBool("run_flag",false);
			}

		}
		public void OnPointerDown(PointerEventData data) 
        {

        }

		void OnDisable()
		{
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}