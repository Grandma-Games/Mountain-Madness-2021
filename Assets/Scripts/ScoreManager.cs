﻿// Singleton to maintain score and game information

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance
    {
        get;
        private set;
    }

    public int totalApples;
    public int totalCarriers;
    public int totalBaskets;
    // public int totalShakers;

    // Main Game
    public TextMeshProUGUI scoreGame;
    public TextMeshProUGUI carriersGame;
    public TextMeshProUGUI basketsGame;
    // public TextMeshProUGUI shakersGame;

    // Store
    public TextMeshProUGUI scoreStore;
    public TextMeshProUGUI carriersStore;
    public TextMeshProUGUI basketsStore;
    // public TextMeshProUGUI shakersStore;

    void Awake()
    {
        if (!Instance) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SaveData sData = SaveSystem.LoadData();
        if (sData != null) {
            totalApples = sData.totalApples;
            totalCarriers = sData.totalCarriers;
            totalBaskets = sData.totalBaskets;
            // totalShakers = sData.totalShakers;
        } else {
            totalApples = 0;
            totalCarriers = 1;
            totalBaskets = 1;
            // totalShakers = 0;
        }
        InvokeRepeating("SaveGame", 0.5f, 60.0f);
    }

    void Update()
    {
        // Game
        scoreGame.text = totalApples.ToString();
        carriersGame.text = "Carriers: " + totalCarriers.ToString();
        basketsGame.text = "Baskets: " + totalBaskets.ToString();
        // shakersGame.text = "Shakers: " + totalShakers.ToString();
        
        // Store
        scoreStore.text = totalApples.ToString();
        carriersStore.text = "Carriers: " + totalCarriers.ToString();
        basketsStore.text = "Baskets: " + totalBaskets.ToString();
        // shakersStore.text = "Shakers: " + totalShakers.ToString();
    }

    void SaveGame()
    {
        SaveSystem.SaveData();
    }
}
