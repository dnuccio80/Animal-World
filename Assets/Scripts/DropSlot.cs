using System;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public static event EventHandler OnAnyIncorrectDragItemDropped;

    private bool hasItemInSlot;
    private AnimalName.AnimalType animalType;

    private void Start()
    {
        GameManager.Instance.OnNewLevel += GameManager_OnNewLevel;
    }

    private void GameManager_OnNewLevel(object sender, System.EventArgs e)
    {
        hasItemInSlot = false;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if(eventData.pointerDrag != null && !hasItemInSlot)
        {
            DragItem draggedItem = eventData.pointerDrag.GetComponent<DragItem>();

            if(draggedItem.GetAnimalType() == animalType)
            {
                hasItemInSlot = true;
                SoundManager.Instance.EmitCorrectSound();
                draggedItem.SetIntoSlot(transform);
                GameManager.Instance.DragIsInSlot();
            }
            else
            {
                OnAnyIncorrectDragItemDropped?.Invoke(this, EventArgs.Empty);
                SoundManager.Instance.EmitIncorrectSound();

            }
        }
    }

    public void SetAnimalTypeReceiver(AnimalName.AnimalType _animalType)
    {
        animalType = _animalType;
    }

}
