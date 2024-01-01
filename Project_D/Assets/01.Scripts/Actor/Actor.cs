using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }
}
