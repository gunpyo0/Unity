[System.Serializable] 
public class Character
{
    public string characterName; 
    public int level = 1; 
    public float baseIncome; 
    public float incomeMultiplier = 1.0f; 

    public float GetIncomePerClick()
    { 
        return baseIncome * incomeMultiplier * level;
    }

}
