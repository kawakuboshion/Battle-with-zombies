using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarDirection : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    void Update()
    {
        //EnemyCanvasをMain Cameraに向かせる
        canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
