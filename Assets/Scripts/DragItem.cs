using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public event EventHandler OnAnimalSOChanged;

    [SerializeField] private TextMeshProUGUI nameText;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 initialPos;
    public bool inSlot;
    public AnimalSO animalSO;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPos = rectTransform.anchoredPosition;
        GameManager.Instance.OnNewLevel += Instance_OnNewLevel;
    }

    private void Instance_OnNewLevel(object sender, EventArgs e)
    {
        rectTransform.SetParent(canvas.transform);
        rectTransform.anchoredPosition = initialPos;
        inSlot = false;
        canvasGroup.blocksRaycasts = true;

    }

    public void SetAnimalSO(AnimalSO _animalSO)
    {
        animalSO = _animalSO;
        nameText.text = animalSO.AnimalType.ToString();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (inSlot) return;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inSlot) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inSlot) return;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (!inSlot) rectTransform.anchoredPosition = initialPos;
    }

    public void SetIntoSlot(Transform slot)
    {
        rectTransform.SetParent(slot);
        rectTransform.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 1f;
        inSlot = true;
    }

    public AnimalName.AnimalType GetAnimalType() => animalSO.AnimalType;


}
