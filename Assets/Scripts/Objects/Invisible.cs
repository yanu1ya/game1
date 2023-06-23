using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Invisible : MonoBehaviour
{
    [SerializeField] TilemapRenderer _tr;

    // Start is called before the first frame update
    void Start()
    {
        _tr.enabled = false;
    }
}
