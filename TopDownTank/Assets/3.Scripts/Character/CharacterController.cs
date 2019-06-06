using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private GunController _barriel;

    [SerializeField]
    private MovingCharacter _moveController;

    [SerializeField]
    private Transform _trans;

    void Start()
    {
        _trans = transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _barriel.ChangeDirection(positionMouse);
        }
    }
}
