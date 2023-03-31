using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] private float _vitesseRotationY = 0.5f;
    [SerializeField] private float _vitesseRotationX = 0.5f;
    [SerializeField] private float _vitesseRotationZ = 0.5f;

    void Update()
    {
        transform.Rotate(_vitesseRotationX, _vitesseRotationY, _vitesseRotationZ);
    }
}