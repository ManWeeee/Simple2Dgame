using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _exp = 0;
    private Vector2 _direction;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private ParticleSystem _levelUpParticleSystem;
    [SerializeField] 
    private TestLevelUp _testDelegate;
    [SerializeField] 
    private float _speed;

    public float CharacterXp
    {
        get => _exp;
        set => _exp = value;
    }
    void giveExp()
    {
        _exp += 10;
    }
    void playLevelUpAnim(object sender, EventArgs e)
    {
        _levelUpParticleSystem.Play();
        Debug.Log("Character was Level Up, levelUp animation was called");
        StartCoroutine(Wait(3));
    }

    IEnumerator Wait(int val) {
        yield return new WaitForSeconds(val);
    }

    void Start()
    {
        _testDelegate.OnLevelUp += playLevelUpAnim;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
        if (_direction.magnitude > 1.0f)
        {
            Debug.Log(_direction.magnitude);
            _direction.Normalize();
        }
        if (_direction.x != 0)
            Flip();
        if (Input.GetKeyDown(KeyCode.I))
        {
            giveExp();
            Debug.Log("This is current Xp of your character" + _exp);
        }

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
