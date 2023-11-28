using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherRotate : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0,0,360 * RotateSpeed * Time.deltaTime);
    }
}
