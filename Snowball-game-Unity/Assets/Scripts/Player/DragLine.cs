using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lr;
    Camera _mainCam;
    [SerializeField] float _lineDepth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        _lr.enabled = true;
        _lr.SetPosition(0, transform.position);
    }
    private void OnMouseDrag()
    {
        Vector3 endpoint = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lineDir = (endpoint - transform.position).normalized;
        _lr.SetPosition(1, transform.position + (lineDir * -_lineDepth));
    }
    private void OnMouseUp()
    {
        _lr.enabled = false;
    }
}
