using UnityEditor.Rendering;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 joystickInputValue;
    private RaycastHit2D tempRaycast;
    public NPCController npc;

    public void Update()
    {
        CheckNPCInteraction();
        CheckMouseClick();
    }

    public void InputJoystick(Vector2 _joystickInputValue)
    {
        joystickInputValue = _joystickInputValue;
    }

    public void CheckNPCInteraction()
    {
        npc = null;
        tempRaycast = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        if(tempRaycast)
        {
            npc = tempRaycast.transform.GetComponent<NPCController>();
        }
    }

    public void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && npc != null)
        {
            npc.Interaction();
        }
    }
}
