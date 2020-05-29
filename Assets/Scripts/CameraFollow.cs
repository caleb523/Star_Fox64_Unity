using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float cameraSpeed;
    public float borderCoefficient;
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        float step = cameraSpeed * Time.deltaTime;
        var pos = target.position;
        var pos2 = transform.position;
        if (((pos.x >= - Manager.instance.xBounds +7) && (pos.x <= Manager.instance.xBounds - 7)) || ((pos2.x >= - Manager.instance.xBounds + 7) && (pos2.x <= Manager.instance.xBounds - 7)))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(borderCoefficient * target.position.x, transform.position.y, transform.position.z), (distance / 2) * step);
        }
        if (((pos.y >= -6) && (pos.y <= 2)) || ((pos2.y >= -6) && (pos2.y <= 6)))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), (distance / 2) * step);
        }
    }
}