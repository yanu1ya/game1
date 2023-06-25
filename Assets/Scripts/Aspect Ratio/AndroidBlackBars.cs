using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidBlackBars : MonoBehaviour
{
    [SerializeField] Canvas _parentCanvas;
    [SerializeField] AspectRatioFitter _arf;

    // Start is called before the first frame update
    void Start()
    {
        float ratio = _parentCanvas.pixelRect.width / _parentCanvas.pixelRect.height;
        _arf.aspectRatio = ratio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
