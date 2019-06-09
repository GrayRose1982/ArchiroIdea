using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;

    public Vector3 _dir;

    [SerializeField]
    private List<Transform> _barriels;

    private Transform _trans;

    void Awake()
    {
        _barriels = new List<Transform>();
    }

    void Start()
    {
        _trans = transform;

        for (int i = 0; i < _trans.childCount; i++)
            _barriels.Add(_trans.GetChild(i));
    }

    public void ChangeDirection(Transform target)
    {
        ChangeDirection(target.position);
    }

    public void Shoot()
    {
        List<float> barrielAngle = new List<float>();
        var baseAngle = _trans.rotation.eulerAngles.z;

        for (int i = 0; i < _barriels.Count; i++)
        {
            var bullet = Instantiate(Bullet, _barriels[i].position, _barriels[i].rotation);
        }
    }

    public void ChangeDirection(Vector3 target)
    {
        _dir = target - _trans.position;
        _dir.Normalize();

        var angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;
        _trans.rotation = Quaternion.Euler(0, 0, angle);
    }
}
