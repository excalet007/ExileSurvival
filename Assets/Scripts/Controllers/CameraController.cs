using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    enum CameraState
    {
        None, FollowTarget
    }

    private CameraState _state;
    private Transform _target;
    
    private Vector3 _offset = new Vector3(0f, 0f, -10f);
    private float _smoothTime = 0.3f;
    private Vector3 _currentVelocity = Vector3.zero;

    public Camera camera;
    
    public void SetFollow(Transform target)
    {
        _target = target;
        _state = CameraState.FollowTarget;
    }

    private void DrawDebugLines(int unitLength = 5) //TODO Debugging Function for terrain
    {
        int x = Mathf.RoundToInt(_target.transform.position.x);
        int y = Mathf.RoundToInt(_target.transform.position.y);
        
        for (int xPos = x - unitLength; xPos <= x + unitLength; xPos++)
        {
            Vector3 start = new Vector3(xPos, y + unitLength);
            Vector3 end = new Vector3(xPos, y - unitLength);
            Debug.DrawLine(start, end, Color.gray);
        }
        
        for (int yPos = y + unitLength; yPos >= y - unitLength; yPos--)
        {
            Vector3 start = new Vector3(x - unitLength, yPos);
            Vector3 end = new Vector3(x + unitLength, yPos);
            Debug.DrawLine(start, end, Color.gray);
        }
    }
    private void LateUpdate()
    {
        if (_target == null)
            return;

        if (_state == CameraState.FollowTarget)
        {
            Vector3 targetPosition = _target.position + _offset;
            transform.position =
                Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);
            
            DrawDebugLines();
        }
    }

    private void Update() //TODO Debugging Function for camera size
    {
        if (Input.GetKey(KeyCode.Q))
            camera.orthographicSize -= Time.deltaTime; ;
        if (Input.GetKey(KeyCode.E))
            camera.orthographicSize += Time.deltaTime; ;
    }
}
