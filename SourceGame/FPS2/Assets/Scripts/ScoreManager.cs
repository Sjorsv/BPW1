using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text ShroomText;
    public int MushroomCount;

    public void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ShroomText.text = "" + MushroomCount;
    }
}
