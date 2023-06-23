using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Diappearing : MonoBehaviour
{
    [SerializeField] TilemapCollider2D _tmc;
    [SerializeField] TilemapRenderer _tmr;

    public float _startDelay;
    private float _delay;
    private float _delayCounter;
    private bool value;

    void Start()
    {
        _delay = 1f;
        _delayCounter = _delay + _startDelay;
        value = false;
    }

    private void Update()
    {
        if (_delayCounter <= 0f)
            TilemapSetUp();

        _delayCounter -= Time.deltaTime;
    }

    void TilemapSetUp()
    {
        _tmr.enabled = value;
        _tmc.enabled = value;

        value = value ? false : true;
        _delayCounter = _delay;
    }
}
