using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _totalWood;
    [SerializeField] private float _totalWater;
    [SerializeField] private float _totalCarrots;
    [SerializeField] private float maxWater = 50;

    public int totalWood { get => _totalWood; set => _totalWood = value; }
    public float TotalWater { get => _totalWater; set => _totalWater = value; }
    public float TotalCarrots { get => _totalCarrots; set => _totalCarrots = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addWater(float value = 10){
        if(_totalWater <= maxWater)
        {
            _totalWater += value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
