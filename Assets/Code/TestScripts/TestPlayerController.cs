using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed;
    Animator _anim;
    CharacterController _charCon;
    Vector3 _direction;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");
        if (_direction.magnitude > 1.0f)
        {
            _direction.Normalize();
        }
        _anim.SetFloat("Speed", _direction.sqrMagnitude);
        _charCon.Move(_direction * _speed * Time.deltaTime);
    }
}
