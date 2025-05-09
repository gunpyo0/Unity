using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string charName;
    public int rarity;
    public Sprite portrait;
    public int level;
    public int baseMoney;
}
