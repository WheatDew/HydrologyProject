using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class RingChartController : MonoBehaviour
{
    public RingChart ringChart;
    public RectTransform center;
    public GameObject point;

    private void Update()
    {
        var serie = ringChart.m_Series.list[0];
        var data = serie.data;
        var serieData = data[0];
        var dataChangeDuration = serie.animation.GetUpdateAnimationDuration();
        var value = serieData.GetFirstData(dataChangeDuration);
        var max = serieData.GetLastData();
        var degree = 360 * value / max;
        if (degree != 0)
        {
            point.SetActive(true);
            center.rotation = Quaternion.AngleAxis(degree, Vector3.back);
        }

        //Debug.Log(ringChart.m_Series.list[0]);
    }
}
