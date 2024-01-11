using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public Status status;
    protected Dictionary<IEnumerator, Coroutine> routines = new Dictionary<IEnumerator, Coroutine>();
    protected Vector3 tempVecter = Vector3.zero;

    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }

    public abstract void Hit(float _damage);
    public abstract void GetDamage(float _damage);


    public void ChangeDirection(Define.Direction _direction)
    {
        if (_direction == Define.Direction.Left) tempVecter.y = 180;
        if (_direction == Define.Direction.Right) tempVecter.y = 0;

        transform.eulerAngles = tempVecter;
    }

    public new void StartCoroutine(IEnumerator _routine)
    {
        routines.Add(_routine, base.StartCoroutine(_routine));
    }

    public new void StopCoroutine(IEnumerator _routine)
    {
        base.StopCoroutine(routines[_routine]);
        routines.Remove(_routine);
    }

    public new void StopAllCoroutines()
    {
        foreach (var routine in routines)
        {
            if(routine.Value != null)
            base.StopCoroutine(routine.Value);
        }

        routines.Clear();
    }
}
