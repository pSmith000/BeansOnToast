using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastBehavior : MonoBehaviour
{
    private bool _clicking;
    private Vector3 _offset;

    private void Update()
    {
        if (_clicking)
        {
            Transform camTrans = Camera.main.transform;
            float dist = Vector3.Dot(transform.position - camTrans.position, camTrans.forward);

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;

            Vector3 tmp = transform.position;
            tmp.x = pos.x;
            tmp.x = Mathf.Clamp(tmp.x, -2.5f, 2.5f);
            transform.position = tmp;
        }
    }

    private void OnMouseDown()
    {
        _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _clicking = true;
    }

    private void OnMouseUp()
    {
        _clicking &= false;
    }
}
