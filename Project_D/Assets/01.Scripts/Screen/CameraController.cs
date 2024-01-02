using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isShake;

    public CameraController()
    {
        isShake = false;
    }


    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }
}
