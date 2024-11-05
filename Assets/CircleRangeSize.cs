using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;

public class CircleRangeSize : MonoBehaviour
{
    public float diameter;
    public Vector3 currentScale;
    private void Start()
    {
        this.gameObject.SetActive(false);
        currentScale = transform.localScale; // ������ ���߱� ����, �ʱ��� localscale�� �����ص�.;

}
    public void UpdateCircleSize(float range)
    {
        this.gameObject.SetActive(true);
        Debug.Log(this.transform.position);
        float diameter = range / 2.25f; //TODO : �� �� �����ؾ���. �������κ��ϰ�
        this.transform.localScale = new Vector3(diameter*currentScale.x, diameter*currentScale.y, diameter*currentScale.z); 
    }
    
    
}
