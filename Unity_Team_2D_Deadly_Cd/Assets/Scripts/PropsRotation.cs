using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRotation : MonoBehaviour
{
    private float _tmp = 0;
    void Update()
    {
        _tmp += Time.deltaTime;
        if (_tmp >= 0.5f)
        {
            _tmp = 0;
            transform.Rotate(new Vector3(0, 0, 45));
        }
    }
}
