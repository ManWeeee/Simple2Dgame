using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnPointObject;
    [SerializeField]
    private GameObject _spawnableObject;
    private Animator _animator;
    private GameObject _newObject;
    private Vector2 _spawnPosition;
    [SerializeField] 
    private Vector3 _offset;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _spawnPosition = _spawnPointObject.transform.position - _offset;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        _animator.SetBool("Spawn", true);
        yield return new WaitForSeconds(0.2f);
        _newObject = Instantiate(_spawnableObject, _spawnPosition, Quaternion.identity);
        _animator.SetBool("Spawn", false);
        yield break;
    }
}
