using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneryForest.SceneItem
{

    public class SceneItem : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        float _minSize = 5f;
        [SerializeField]
        float _maxSize = 7f;
        Animator _animator;
        bool _randomSize;
        bool _shakeAtStart;
        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_randomSize)
            {
                RandomSize();
            }
        }

        private void RandomSize()
        {
            float size = Random.Range(_minSize, _maxSize);
            transform.localScale = new Vector2(size, size);
        }
    }
}
