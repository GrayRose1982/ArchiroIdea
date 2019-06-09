using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBullet : MonoBehaviour
{
    [SerializeField]
    private Vector2 _dir;
    [SerializeField]
    private float _speed = 5f;

    private Transform _trans;

    void Awake()
    {
        _trans = transform;
        _dir = Vector2.zero;
    }

    void OnEnable()
    {
        var angle = Mathf.Deg2Rad * (_trans.rotation.eulerAngles.z+90 );
        _dir.x = Mathf.Cos(angle);
        _dir.y = Mathf.Sin(angle);
    }

    void Start()
    {

    }

    void Update()
    {
        Moving();
    }

    public void SetSide(bool isPlayer)
    {

    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void SetDirection(Vector2 newDir)
    {

    }

    public void SetAngle(float angle)
    {

    }

    public void Moving()
    {
        //_dir = newDir;
        //_dir.Normalize();

        _trans.position = (Vector3)(_dir * _speed * Time.deltaTime) + _trans.position;
        //_trans.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90);

    }
}
