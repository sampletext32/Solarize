using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal.Input;

public class CameraSetupper : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        if (_camera)
        {
            //distance = sqrt(x^2+x^2+x^2)
            float cameraCoordinate = Constants.CameraDistanceFromCenter / Mathf.Sqrt(3);
            _camera.transform.position = new Vector3(1, 1, -1) * cameraCoordinate / 3;
            _camera.transform.rotation = Quaternion.Euler(Constants.CameraIsometricAngle, -45, 0);

            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }
        else
        {
            Debug.LogError("Camera Settuper Cant Find A Camera");

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    public Transform target; // Inspector> Assign the LookAt Camera Target Object

    float xSpeed = 250.0f; // Speed of x rotation
    float ySpeed = 120.0f; // Speed of y rotation

    float yMinLimit = 20f; // y minimum rotation limit
    float yMaxLimit = 70f; // y maximum rotation limit

    private float x;
    private float y;

    private float smooth;

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.5f, -Constants.CameraDistanceFromCenter) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

        smooth -= Input.GetAxis("Mouse ScrollWheel") * 10f;

        Constants.CameraDistanceFromCenter += smooth;
        if (Constants.CameraDistanceFromCenter < 1)
            Constants.CameraDistanceFromCenter = 1;
        if (Constants.CameraDistanceFromCenter > 250)
            Constants.CameraDistanceFromCenter = 250;
        if (Mathf.Abs(smooth) > 0.001f)
            smooth /= 1.2f;
        else
        {
            smooth = 0f;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}