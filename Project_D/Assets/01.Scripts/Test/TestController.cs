using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private Dictionary<IEnumerator, Coroutine> routines = new Dictionary<IEnumerator, Coroutine>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(sdsd());
        if (Input.GetKeyDown(KeyCode.Space))
            StopCoroutine(sdsd());

    }

    private IEnumerator sdsd()
    {
        while (true)
        {
            Debug.Log("µµ´Â Áß");
            yield return null;
        }
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
}
