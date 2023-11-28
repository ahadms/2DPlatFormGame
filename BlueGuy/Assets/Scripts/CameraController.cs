using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector2 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x + offset.x,Player.position.y+offset.y,transform.position.z);
    }
}
