using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SceneryForest.SceneItem
{
    public enum InteractionType
    {
        Addition
    }

    public class SpawnByCursor : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        SceneItem _prefab;
        InteractionType _interaction;

        Vector2 _spawnPos;
        #endregion

        public SceneItem AdditionItem
        {
            get => _prefab;
            set => _prefab = value;
        }

        public InteractionType CurrentInteraction
        {
            get => _interaction;
            set => _interaction = value;
        }

        private void Update()
        {
            SpawnWithCursor();
        }

        private void SpawnWithCursor()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(_prefab, _spawnPos, Quaternion.identity);
            }
        }

    }
}
