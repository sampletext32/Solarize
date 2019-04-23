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

    public Transform target; // Inspector> Assign the LookAt Camera Target Object

    float xSpeed = 360f; // Speed of x rotation
    float ySpeed = 360f / 3f; // Speed of y rotation

    float yMinLimit = 0f; // y minimum rotation limit
    float yMaxLimit = 90f; // y maximum rotation limit

    private float _xRotation;
    private float _yRotation;

    private float _zoomSmooth;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        if (_camera)
        {
            minimumCameraDistance = Constants.UnityUnitConverter.FromAstronomicalUnits(1);
            maximumCameraDistance = Constants.UnityUnitConverter.FromAstronomicalUnits(10);

            //distance = sqrt(x^2+x^2+x^2)
            //На расстоянии 5 астрономических единиц
            float cameraDistance = Constants.UnityUnitConverter.FromAstronomicalUnits(5);
            _camera.transform.position = new Vector3(1, 1, -1) * cameraDistance / 3;
            _camera.transform.rotation = Quaternion.Euler(Constants.CameraIsometricAngle, -45, 0);

            var angles = transform.eulerAngles;
            _xRotation = angles.y;
            _yRotation = angles.x;
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

    private float _forwardCoefficient = 0f;
    private float minimumCameraDistance;
    private float maximumCameraDistance;

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(2))
            {
                _xRotation += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                _yRotation -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            _yRotation = ClampAngle(_yRotation, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.5f, -Constants.CameraDistanceFromCenter) +
                               target.position;

            _camera.transform.rotation = rotation;
            _camera.transform.position = position;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _forwardCoefficient += 0.01f;
            if (_forwardCoefficient > 1f)
            {
                _forwardCoefficient = 1f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _forwardCoefficient -= 0.01f;
            if (_forwardCoefficient < -1f)
            {
                _forwardCoefficient = -1f;
            }
        }
        else
        {
            if (Math.Abs(_forwardCoefficient) > 0.001f)
            {
                _forwardCoefficient /= 1.2f;
            }
            else
            {
                _forwardCoefficient = 0f;
            }
        }

        _zoomSmooth -= _forwardCoefficient * 10f;

        Constants.CameraDistanceFromCenter += _zoomSmooth;
        if (Constants.CameraDistanceFromCenter < minimumCameraDistance)
        {
            Constants.CameraDistanceFromCenter = minimumCameraDistance;
        }

        if (Constants.CameraDistanceFromCenter > maximumCameraDistance)
        {
            Constants.CameraDistanceFromCenter = maximumCameraDistance;
        }

        if (Mathf.Abs(_zoomSmooth) > 0.001f)
        {
            _zoomSmooth /= 1.2f;
        }
        else
        {
            _zoomSmooth = 0f;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }
}