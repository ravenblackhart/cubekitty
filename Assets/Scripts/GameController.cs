using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region GUI

    public TextMeshProUGUI HealthCounter;
    public TextMeshProUGUI MarblesCounter;
    
    

    public int HealthPoints = 5;
    public int Marbles = 5;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthCounter.text = HealthPoints.ToString();
        MarblesCounter.text = Marbles.ToString();
    }
}
