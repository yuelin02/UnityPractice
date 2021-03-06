﻿using UnityEngine;
using System.Collections;
using System;

public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    public int maxDepth;
    private int depth;

    public float childScale;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if(depth < maxDepth)
        {
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.up);
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.right);
            //new GameObject("Fractal Child").
            //    AddComponent<Fractal>().Initialize(this, Vector3.left);

            StartCoroutine(CreateChildren()); //Create an iterator, and pass it to the StartCoroutine method
        }
    }

    internal void Initialize(BetterFractal betterFractal, Vector3 up, Quaternion identity)
    {
        throw new NotImplementedException();
    }

    private IEnumerator CreateChildren()
    {
        // Enumeration - iterator: the concept of going through some collection one item at a time
        // like looping over all elements in an array

        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.up, Quaternion.identity);
        //new GameObject("Fractal Child").
        //    AddComponent<Fractal>().Initialize(this, Vector3.down, Quaternion.identity);

        //yield return new WaitForSeconds(0.1f);
        //new GameObject("Fractal Child").
        //    AddComponent<Fractal>().Initialize(this, Vector3.forward);
        //new GameObject("Fractal Child").
        //    AddComponent<Fractal>().Initialize(this, Vector3.back);

        yield return new WaitForSeconds(0.1f);
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.right, Quaternion.Euler(0f, 0f, -90f));
        new GameObject("Fractal Child").
            AddComponent<Fractal>().Initialize(this, Vector3.left, Quaternion.Euler(0f, 0f, 90f));
        
    }

    private void Initialize(Fractal parent, Vector3 direction, Quaternion orientation)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;

        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);
        transform.localRotation = orientation;
    }
}