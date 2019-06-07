using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankController : MonoBehaviour
{
    [SerializeField]
    private GunController _barriel;

    [SerializeField]
    private MovingCharacter _moveController;

    [SerializeField]
    private List<Transform> _enemy;

    [SerializeField]
    private Transform _trans;


    [Header("In-game"), SerializeField]
    private bool _isMoving = false;

    [SerializeField]
    private Transform _currentTarget;


    void Reset()
    {
        if (!_barriel)
            _barriel = GetComponentInChildren<GunController>();

        if (_moveController)
            _moveController = GetComponent<MovingCharacter>();
    }

    void Start()
    {
        _trans = transform;
    }

    void Update()
    {
        BeforUpdate();

        Vector2 _dir;
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        if (Vector2.Distance(_dir, Vector2.zero) > float.Epsilon)
        {
            _isMoving = true;
            _moveController.Moving(_dir);
        }

        if (Input.GetMouseButton(0))
        {
            var positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _barriel.ChangeDirection(positionMouse);
        }

        AfterUpdate();
    }



    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("Object hit : " + hit.name);
        if (!_enemy.Contains(hit.transform))
        {
            _enemy.Add(hit.transform);
            _enemy.Sort((x, y) =>
            {
                var dis1 = Vector2.Distance(x.position, _trans.position);
                var dis2 = Vector2.Distance(y.position, _trans.position);
                return dis1 < dis2 ? -1 : dis1 > dis2 ? 1 : 0;
            });
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (_enemy.Contains(hit.transform))
        {
            _enemy.Remove(hit.transform);
        }
    }

    void BeforUpdate()
    {

    }

    void AfterUpdate()
    {

    }
}
