using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Food Scriptable", order = 1)]
public class FoodScriptable : ScriptableObject
{
    public string foodName;
    public enum Doneness
    {
        Raw = 0,
        Done = 1,
        Burnt = 2
    }

    public Doneness doneness;
    public float[] satisfactionPoint = new float[3];
    public float[] cookingTimer = new float[3];
}
