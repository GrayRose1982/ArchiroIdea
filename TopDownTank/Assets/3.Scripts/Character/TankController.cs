using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankController : MonoBehaviour
{
    public static TankController Instance;
    [Header("Reference")]
    [SerializeField]
    private Transform _body;
    [SerializeField]
    private GunController _barriel;

    [SerializeField]
    private MovingCharacter _moveController;

    [SerializeField]
    private List<Transform> _enemy;

    [Header("In-game"), SerializeField]
    private bool _isMoving = false;
    [SerializeField]
    private Transform _currentTarget;
    [SerializeField]
    private Transform _trans;
  

    void Reset()
    {
        if (!_barriel)
            _barriel = GetComponentInChildren<GunController>();

        if (_moveController)
            _moveController = GetComponent<MovingCharacter>();
    }

    void Awake()
    {
        Instance = this;
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

            _body.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90);
        }

        if (!_currentTarget)
        {
            var positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _barriel.ChangeDirection(positionMouse);
        }
        else
        {
            _barriel.ChangeDirection(_currentTarget.position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _barriel.Shoot();
        }

        AfterUpdate();
    }



    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("Object hit : " + hit.name);
        if (!_enemy.Contains(hit.transform))
        {
            _enemy.Add(hit.transform);

            SortEnemyList();
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (_enemy.Contains(hit.transform))
        {
            _enemy.Remove(hit.transform);
            SortEnemyList();
        }
    }

    private void SortEnemyList()
    {
        _enemy.Sort((x, y) =>
        {
            var dis1 = Vector2.Distance(x.position, _trans.position);
            var dis2 = Vector2.Distance(y.position, _trans.position);
            return dis1 < dis2 ? -1 : dis1 > dis2 ? 1 : 0;
        });

        if (_enemy.Count > 0)
            _currentTarget = _enemy[0];
        else _currentTarget = null;
    }

    void BeforUpdate()
    {

    }

    void AfterUpdate()
    {

    }
}
