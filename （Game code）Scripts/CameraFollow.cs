using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//����Ŀ�� ������ΪMain Camera��
    public float smoothing;//ƽ������

    public Vector2 minPosition;//���ٱ߽����½�
    public Vector2 MaxPosition;//���ٱ߽����Ͻ�

    // Start is called before the first frame update
    void Start()
    {
     
    }
    void LateUpdate()//��󴥷�
    {
        if (target != null)
        {
            if (transform.position != target.position)//ʵ�ָ���
            {
                Vector3 targetPos = target.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, MaxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, MaxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);//����ƽ������ʵ��ƽ����λ��ת��
            }
        }
    }
    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        MaxPosition = maxPos;
    }
}
