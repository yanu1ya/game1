using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _speed = 2f;
    private float _endPosX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartFloating(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));
        
        if (transform.position.x > _endPosX)
            Destroy(gameObject);
    }
}
