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
        currentScale = transform.localScale; // 비율을 맞추기 위해, 초기의 localscale을 저장해둠.;

}
    public void UpdateCircleSize(float range)
    {
        this.gameObject.SetActive(true);
        //Debug.Log(this.transform.position);
        float diameter = range*hexsize;
        this.transform.localScale = new Vector3(diameter*currentScale.x, diameter*currentScale.y, diameter*currentScale.z); 
    }
}
