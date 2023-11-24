using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//跟踪目标 （设置为Main Camera）
    public float smoothing;//平滑常数

    public Vector2 minPosition;//跟踪边界左下界
    public Vector2 MaxPosition;//跟踪边界右上界

    // Start is called before the first frame update
    void Start()
    {
     
    }
    void LateUpdate()//随后触发
    {
        if (target != null)
        {
            if (transform.position != target.position)//实现跟随
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, MaxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, MaxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//设置平滑常数实现平滑的位置转换
            }
        }
    }
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        MaxPosition = maxPos;
    }
}
