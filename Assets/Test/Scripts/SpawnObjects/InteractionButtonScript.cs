using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneryForest.SceneItem
{
    public class InteractionButtonScript : MonoBehaviour
    {
        #region Inspector]
        [SerializeField]
        protected SpawnByCursor _spawnByCursor;
        [SerializeField]
        protected InteractionType _interactionType;
        #endregion

        public virtual void OnClick()
        {
            _spawnByCursor.CurrentInteraction = _interactionType;
        }
    }
}
