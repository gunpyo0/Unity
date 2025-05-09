using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();


    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddGoldFromCharacters();
        }
    }

    void AddGoldFromCharacters()
    {
        foreach (var character in characters)
        {
            if (MoneyManager.Instance != null)
            {
                MoneyManager.Instance.GetMoney(Mathf.RoundToInt(character.GetIncomePerClick()));
            }

        }
    }
}
