using System;
using UnityEngine;
using UnityEngine.UI;

public class DropAnimalContainer : MonoBehaviour
{

    [SerializeField] private Image animalImage;
    [SerializeField] private DropSlot dropSlot;

    private AnimalSO animalSO;

    public void SetAnimalSO(AnimalSO _animalSO)
    {
        animalSO = _animalSO;
        animalImage.sprite = animalSO.AnimalImage;
        dropSlot.SetAnimalTypeReceiver(animalSO.AnimalType);
    }

}
