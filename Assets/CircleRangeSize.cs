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
        currentScale = transform.localScale; // 비율을 맞추기 위해, 초기의 localscale을 저장해둠.;

}
    public void UpdateCircleSize(float range)
    {
        this.gameObject.SetActive(true);
        Debug.Log(this.transform.position);
        float diameter = range / 2.25f; //TODO : 이 식 수정해야함. 동적으로변하게
        this.transform.localScale = new Vector3(diameter*currentScale.x, diameter*currentScale.y, diameter*currentScale.z); 
    }
    
    
}
