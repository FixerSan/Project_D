using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public void Hit()
    {

    }

    public void GetDamage()
    {

    }
}
