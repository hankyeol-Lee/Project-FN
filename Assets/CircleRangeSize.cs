using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleRangeSize : MonoBehaviour
{
    public float hexsize = 0.5f;
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
        //Debug.Log(this.transform.position);
        float diameter = range*hexsize;
        this.transform.localScale = new Vector3(diameter*currentScale.x, diameter*currentScale.y, diameter*currentScale.z); 
    }
}
