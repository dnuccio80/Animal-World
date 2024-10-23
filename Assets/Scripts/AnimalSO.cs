using UnityEngine;

[CreateAssetMenu]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private Sprite animalImage;
    [SerializeField] private AnimalName.AnimalType animalType;

    public Sprite AnimalImage {  get { return animalImage; } }
    public AnimalName.AnimalType AnimalType { get {  return animalType; } }

}


