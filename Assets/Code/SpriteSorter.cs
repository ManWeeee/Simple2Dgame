using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSorter : MonoBehaviour
{

    
    [SerializeField] private bool isStatic = false;
    [SerializeField] private float offset = 0;
    private int _sortingOrderBase = 0;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + offset);
        if(isStatic)
        {
            Destroy(this);
        }
    }
}
