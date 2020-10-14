using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StructureCognitiveIcon : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public RectTransform pointAnimation;
    public GameObject Description;
    private bool IsMouseOn;

    private void Start()
    {
        StartCoroutine(PointAnimationUpdata());
    }

    private void Update()
    {
        
    }

    IEnumerator PointAnimationUpdata()
    {
        while (true)
        {
            pointAnimation.rotation *= Quaternion.AngleAxis(100 * Time.deltaTime, Vector3.back);
            yield return new WaitForSeconds(0.0125f);
        }
    }

    public void DisplayOrHiddenDescription()
    {
        if (Description.activeSelf)
            Description.SetActive(false);
        else
            Description.SetActive(true);
    }

    public void DisplayCognitivePoint()
    {
        FindObjectOfType<StructureCognitiveModuleSpawner>().CreateCognitivePoint();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseOn = false;
    }
}
