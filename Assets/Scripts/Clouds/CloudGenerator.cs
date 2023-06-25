using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] float _spawnInterval;
    [SerializeField] GameObject _endPoint;

    Vector3 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCloud(Vector3 _startPos)
    {
        int randIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randIndex]);

        float startY = UnityEngine.Random.Range(_startPos.y - 1f, _startPos.y + 1f);
        cloud.transform.position = new Vector3(_startPos.x, startY, _startPos.z);

        float scale = UnityEngine.Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<Cloud>().StartFloating(speed, _endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        SpawnCloud(_startPos);

        Invoke("AttemptSpawn", _spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = _startPos + Vector3.right * (i * 10);
            SpawnCloud(spawnPos);
        }
    }
}
