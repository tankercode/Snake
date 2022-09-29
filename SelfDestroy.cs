using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public string OtherColliderTag = "Player";

    [SerializeField]
    public GameObject _destroyEffect;

    [SerializeField]
    public Vector3 _destroyEffectOffcet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == OtherColliderTag) {
            Instantiate(_destroyEffect, transform.position+ _destroyEffectOffcet, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
