using UnityEngine;
using UnityEngine.UI;

public class LifeContainerUI : MonoBehaviour
{


    [SerializeField] private Image[] hearthImagesArray;

    private int lifes = 4;

    private void Start()
    {
        UpdateVisual();
        DropSlot.OnAnyIncorrectDragItemDropped += DropSlot_OnAnyIncorrectDragItemDropped;
    }

    private void DropSlot_OnAnyIncorrectDragItemDropped(object sender, System.EventArgs e)
    {
        lifes--;
        UpdateVisual();
        if (lifes <= 0) GameManager.Instance.GameOver(); 
    }

    private void UpdateVisual()
    {

        foreach (Image hearth in hearthImagesArray)
        {
            hearth.color = Color.black;
        }

        for (int i = 0; i < lifes;  i++)
        {
            hearthImagesArray[i].color = Color.white;
        }

    }


    private void OnDestroy()
    {
        DropSlot.OnAnyIncorrectDragItemDropped -= DropSlot_OnAnyIncorrectDragItemDropped;

    }
}
