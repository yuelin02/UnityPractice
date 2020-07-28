﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(FPSCounter))]
public class FPSDisplay : MonoBehaviour
{
    public Text fpsLabel;

    FPSCounter fpsCounter;

    private void Awake()
    {
        fpsCounter = GetComponent<FPSCounter>();
    }

    private void Update()
    {
        fpsLabel.text = Mathf.Clamp(fpsCounter.FPS, 0, 99).ToString();
    }
}
