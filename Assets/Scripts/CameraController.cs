//Needs a way to jump from level to level
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Transform camTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Camera.main.transform.position = camTarget.position;
            TimerManager.RestartTimer();
        }
    }
}
