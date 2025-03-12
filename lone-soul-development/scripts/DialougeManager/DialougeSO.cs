using UnityEngine;

[CreateAssetMenu(fileName = "characterDialouge", menuName = "Dialouges/CharacterDialouge", order = 1)]
public class DialougeSO : ScriptableObject
{
    public string speaker;
    public string[] sentences;
}
