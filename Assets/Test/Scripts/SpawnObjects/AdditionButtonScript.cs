using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneryForest.SceneItem
{
    public class AdditionButtonScript : InteractionButtonScript
    {
        #region Inspector
        [SerializeField]
        SceneItem _prefab;
        #endregion

        public override void OnClick()
        {
            base.OnClick();
            _spawnByCursor.AdditionItem = _prefab;
        }
    }
}