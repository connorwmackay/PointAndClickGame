using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private bool isStartCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (!isStartCamera)
        {
            camera.enabled = false;
        }
        else
        {
            camera.enabled = true;
            Camera.SetupCurrent(camera);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Camera mainCamera = Camera.main;

            if (mainCamera.GetInstanceID() != camera.GetInstanceID())
            {
                mainCamera.enabled = false;
                camera.enabled = true;
                Camera.SetupCurrent(camera);
            }
        }
    }
}
