using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private float _timeDestroy = 2f;

    void OnEnable()
    {
        Destroy(gameObject, _timeDestroy);
    }
}
