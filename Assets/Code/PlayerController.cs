using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        if(_direction.x != 0)
            Flip();
            
        _anim.SetFloat("Speed", _direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * _speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (_direction.x > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
