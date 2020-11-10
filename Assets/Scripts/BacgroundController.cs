﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundController : MonoBehaviour
{

    public float scrollSpeed;
    private MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }


    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}