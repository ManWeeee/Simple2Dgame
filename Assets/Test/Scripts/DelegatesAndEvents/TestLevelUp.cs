using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelUp : MonoBehaviour
{
    public EventHandler OnLevelUp;
    private float _levelUp = 100;
    [SerializeField]
    private PlayerController _controller;

    // Update is called once per frame
    void Update()
    {
        if (_controller.CharacterXp >= _levelUp)
        {
            OnLevelUp?.Invoke(this, EventArgs.Empty);
            _levelUp = _levelUp + _levelUp / 10;
            _controller.CharacterXp = 0;
            Debug.Log("Know its " + _levelUp + " exp to get new level");
        }
    }
}
