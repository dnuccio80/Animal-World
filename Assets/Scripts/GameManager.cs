using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnNewLevel;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameOver;

    [SerializeField] private AnimalSO[] animalsSOArray;
    [SerializeField] private DragItem[] dragArray;
    [SerializeField] private DropAnimalContainer[] dropAnimalContainerArray;

    private List<AnimalSO> animalSOList = new List<AnimalSO>();
    private List<AnimalSO> dragNameList = new List<AnimalSO>();
    private List<AnimalSO> slotAnimalList = new List<AnimalSO>();

    private bool isGamePaused;
    private int dragsInSLot;
    private int score;
    private int level = 1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        CreateSOList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreateSOList();
            OnNewLevel?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }

    private void CreateSOList()
    {
        animalSOList.Clear();

        for (int i = 0; i < 3; i++)
        {
            AnimalSO animal = GetRandonAnimalSO();

            while (animalSOList.Contains(animal))
            {
                animal = GetRandonAnimalSO();
            };

            animalSOList.Add(animal);
        }

        SetDragNameList();
        SetSlotAnimalList();
    }

    private void SetDragNameList()
    {
        dragNameList.Clear();

        foreach (AnimalSO animal in animalSOList)
        {
            dragNameList.Add(animal);
        }

        foreach (DragItem dragItem in dragArray)
        {
            int index = GetRandomNumber(dragNameList.Count);

            AnimalSO animalInList = dragNameList[index];

            dragItem.SetAnimalSO(animalInList);
            dragNameList.Remove(animalInList);

        }

    }

    private void SetSlotAnimalList()
    {
        slotAnimalList.Clear();

        foreach (AnimalSO animal in animalSOList)
        {
            slotAnimalList.Add(animal);
        }

        slotAnimalList.RemoveAt(GetRandomNumber(slotAnimalList.Count));


        foreach (DropAnimalContainer dropAnimal in dropAnimalContainerArray)
        {
            int index = GetRandomNumber(slotAnimalList.Count);

            AnimalSO animalInList = slotAnimalList[index];

            dropAnimal.SetAnimalSO(animalInList);
            slotAnimalList.Remove(animalInList);
        }
    }

    private AnimalSO GetRandonAnimalSO()
    {
        return animalsSOArray[UnityEngine.Random.Range(0, animalsSOArray.Length)];
    }

    private int GetRandomNumber(int maxNumber)
    {
        return UnityEngine.Random.Range(0, maxNumber);
    }

    public void TogglePauseGame()
    {

        if (!isGamePaused)
        {
            OnGamePaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }

        isGamePaused = !isGamePaused;


    }

    public void DragIsInSlot()
    {
        dragsInSLot++;

        if (dragsInSLot == 2)
        {
            CreateNewLevel();
        }
    }

    private void CreateNewLevel()
    {
        CreateSOList();
        score += 80;
        level++;
        dragsInSLot = 0;
        OnNewLevel?.Invoke(this, EventArgs.Empty);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public int GetCurrentScore() => score;
    public int GetCurrentLevel() => level;

}
