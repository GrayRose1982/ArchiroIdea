using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Vector3 _dir;

    private Transform _trans;

    void Start()
    {
        _trans = transform;
        Debug.Log(_trans.name);
    }

    public void ChangeDirection(Transform target)
    {
        ChangeDirection(target.position);
    }

    public void ChangeDirection(Vector3 target)
    {
        _dir = target - _trans.position;
        _dir.Normalize();
        var angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;

        _trans.rotation = Quaternion.Euler(0, 0, angle);
    }
}
