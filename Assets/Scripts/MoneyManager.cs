using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money { get { return money; } }
    public static MoneyManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMoney(int moneyValue)
    {
        money += moneyValue;
    }    
}
