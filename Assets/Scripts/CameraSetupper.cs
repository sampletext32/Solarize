using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal.Input;

public class CameraSetupper : MonoBehaviour
{
    private Camera _camera;

    public Transform target; // Inspector> Assign the LookAt Camera Target Object

    private float xRotationSpeed = 360f * 0.02f; // Speed of x rotation
    private float yRotationSpeed = 360f / 3f * 0.02f; // Speed of y rotation

    private float yMinLimit = 0f; // y minimum rotation limit
    private float yMaxLimit = 90f; // y maximum rotation limit

    private float _xRotation; // x current rotation
    private float _yRotation; // y current rotation

    private float _minimumCameraDistance;
    private float _maximumCameraDistance;
    private float _currentCameraDistance;


    private float _cameraMaxSpeed = Constants.UnityUnitConverter.FromAstronomicalUnits(5f);
    private float _cameraAcceleration = Constants.UnityUnitConverter.FromAstronomicalUnits(5f);
    private float _cameraCurrentSpeed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        if (_camera)
        {
            _minimumCameraDistance = (1f + 0.2f) / Mathf.Tan(_camera.fieldOfView / 2);
            _maximumCameraDistance = Constants.UnityUnitConverter.FromAstronomicalUnits(10);

            //distance = sqrt(x^2+x^2+x^2)
            //На расстоянии 5 астрономических единиц
            _currentCameraDistance = Constants.UnityUnitConverter.FromAstronomicalUnits(5);
            _camera.transform.position = new Vector3(1, 1, -1) * _currentCameraDistance;
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

    private bool _isCameraStopping;

    void Update()
    {
        #region WORKING

        if (target)
        {
            if (Input.GetMouseButton(2))
            {
                _xRotation += Input.GetAxis("Mouse X") * xRotationSpeed;
                _yRotation -= Input.GetAxis("Mouse Y") * yRotationSpeed;
            }

            //if (Input.GetKey(KeyCode.A))
            //{
            //    _xRotation += xRotationSpeed / 2f;
            //}
            //
            //if (Input.GetKey(KeyCode.D))
            //{
            //    _xRotation -= xRotationSpeed / 2f;
            //}

            _yRotation = ClampAngle(_yRotation, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -_currentCameraDistance) + target.position;

            _camera.transform.rotation = rotation;
            _camera.transform.position = position;
        }

        #endregion

        if (Input.GetKey(KeyCode.W))
        {
            if (_cameraCurrentSpeed < 0) _cameraCurrentSpeed = 0f;
            _cameraCurrentSpeed += _cameraAcceleration * Time.deltaTime;
            if (_cameraCurrentSpeed > _cameraMaxSpeed)
            {
                _cameraCurrentSpeed = _cameraMaxSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (_cameraCurrentSpeed > 0) _cameraCurrentSpeed = 0f;
            _cameraCurrentSpeed -= _cameraAcceleration * Time.deltaTime;
            if (_cameraCurrentSpeed < -_cameraMaxSpeed)
            {
                _cameraCurrentSpeed = -_cameraMaxSpeed;
            }
        }
        else
        {
            if (_cameraCurrentSpeed > 0) _cameraCurrentSpeed -= _cameraAcceleration * 2f * Time.deltaTime;
            else if (_cameraCurrentSpeed < 0) _cameraCurrentSpeed += _cameraAcceleration * 2f * Time.deltaTime;
            if (Mathf.Abs(_cameraCurrentSpeed) - _cameraAcceleration * 2f * Time.deltaTime < 0f)
                _cameraCurrentSpeed = 0f;
        }

        _currentCameraDistance -= _cameraCurrentSpeed * Time.deltaTime;

        if (_currentCameraDistance > _maximumCameraDistance) _currentCameraDistance = _maximumCameraDistance;
        if (_currentCameraDistance < _minimumCameraDistance) _currentCameraDistance = _minimumCameraDistance;
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