using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{
    [SerializeField]
    private Vector2 _dir;
    [SerializeField]
    private float _speed;

    private Transform _trans;


    void Start()
    {
        _trans = transform;
        _dir = Vector2.zero;
    }

    void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        _dir.Normalize();

        if (Vector2.Distance(_dir, Vector2.zero) <= 0)
        {
            _trans.position = (Vector3)(_dir * _speed * Time.deltaTime) + _trans.position;
            _trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90);
        }
    }
}
