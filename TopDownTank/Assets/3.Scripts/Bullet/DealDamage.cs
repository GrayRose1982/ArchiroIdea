using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public ParticleSystem efx;

    void OnTrigegrEnter2D(Collider2D hitObj)
    {
        var angle = (transform.rotation.eulerAngles.z+90) * Mathf.Deg2Rad;
        Vector2 dic = Vector2.zero;
        dic.x = Mathf.Cos(angle);
        dic.y = Mathf.Sin(angle);
        dic *= .25f;
        var postion = (Vector2)transform.position + dic;
        var e = Instantiate(efx, postion, Quaternion.identity);
        e.Play();
        gameObject.SetActive(false);
    }
}
