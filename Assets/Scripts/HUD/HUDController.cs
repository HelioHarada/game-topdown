using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControll : MonoBehaviour
{
    [Header("Item colactable")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Text woodUICount;
    [SerializeField] private Text carrotUICount;

     [Header("Tool Panel")]
    // [SerializeField] private Image axeImageUI;
    // [SerializeField] private Image shovelImageUI;
    // [SerializeField] private Image bucketImageUI;

    public List<Image> toolUI = new List<Image>();
    [SerializeField] private Color colorSelected;
    [SerializeField] private Color colorDisable;


    [SerializeField]  private PlayerItems playerItem;
    [SerializeField]  private Player player;



    void Awake()
    {
        playerItem = FindAnyObjectByType<PlayerItems>();
        // Pega o script player pq está no mesmo obj
        player = playerItem.GetComponent<Player>();

    }
   
    // Start is called before the first frame update
    void Start()
    {

        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    
       
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItem.TotalWater/playerItem.MaxWater;
        woodUIBar.fillAmount = playerItem.TotalWood/playerItem.MaxWood;
        carrotUIBar.fillAmount = playerItem.TotalCarrots/playerItem.MaxCarrot;
        woodUICount.text = playerItem.TotalWood.ToString();
        carrotUICount.text = playerItem.TotalCarrots.ToString();

        
        if(toolUI.Count >= player.HandlingObj)
        {
            
            // Debug.Log(toolUI.Count +" - "+player.HandlingObj);
            for (int i = 1; i <= toolUI.Count; i++)
            {
                toolUI[i-1].color = (player.HandlingObj == i) ? colorSelected : colorDisable;

                // Logica por traz;
                // if(i <= toolUI.Count)
                // {
                //     if(player.HandlingObj == i )
                //     {
                //         toolUI[i-1].color = colorSelected;
                //         // Debug.Log("Selected:"+i);
                //     }else{
                //         toolUI[i-1].color = colorDisable;
                //         // Debug.Log("Disable: "+i);
                //     }
                // }
            }
            
        }
        
        
       


    }
}
