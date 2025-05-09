using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public List<Character> characters = new List<Character>();

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }


}
