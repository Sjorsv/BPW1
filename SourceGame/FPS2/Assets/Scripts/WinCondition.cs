using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject victoryScreen;
    public int MushroomCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.MushroomCount == 7)
        {
            VictoryScreen();
        }
    }
    public void VictoryScreen()
    {

        victoryScreen.SetActive(true);

    }
}
