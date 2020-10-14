using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainPageButton : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public Sprite SelectedSprite;
    public Sprite NormalSprite;
    public MainPageButton[] MainPageButtonGroup;
    [System.NonSerialized]
    public Image selfImage;
    [System.NonSerialized]
    public bool isSelected;

    private void Start()
    {
        selfImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isSelected)
        selfImage.sprite = SelectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!isSelected)
        selfImage.sprite = NormalSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach(var item in MainPageButtonGroup)
        {
            item.selfImage.sprite = item.NormalSprite;
            item.isSelected = false;
        }
        selfImage.sprite = SelectedSprite;
        isSelected = true;
    }
}
