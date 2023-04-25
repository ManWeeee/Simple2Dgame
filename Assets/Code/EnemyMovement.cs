using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] 
    float _moveSpeed;
    [SerializeField]
    float _minDistance;
    Transform _target;
    Rigidbody2D _rb;
    Vector2 _moveDirection;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _target.position) > _minDistance)
        {
            _moveDirection = (_target.position - transform.position).normalized;
            _rb.MovePosition(_rb.position + _moveDirection * _moveSpeed * Time.deltaTime); 
            //_rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * _moveSpeed;
            //transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        }
        else
        {
            _rb.MovePosition(transform.position);
        }
    }

    //To make enemy stop while its colliding another enemy, fix rigidbody bug so that the player can push enemy

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            /*collision.rigidbody.AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);*/
        }
    }
}
