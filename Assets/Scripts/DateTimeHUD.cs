﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeHUD : MonoBehaviour
{
    public static DateTimeHUD Instance;
    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button phoneButton;
    [SerializeField] private GameObject questMenu;
    [SerializeField] private GameObject phonePrefab;
    private GameObject phoneCache;
    public static bool isPhoneShown = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateDateTime();
        questMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPhoneVisibility(bool isVisible) => phoneButton.gameObject.SetActive(isVisible);
    
    public void ShowQuestMenu(bool isVisible) =>  questMenu.SetActive(isVisible);
    
    public void UpdateDateTime()
    {
        var dateTime = GameDynamicData.Instance.CurrentDateTime;
        timeText.text = dateTime.ToString("t");
        dateText.text = $"{dateTime.ToShortDateString()} {dateTime:ddd}";
        moneyText.text = $"${GameDynamicData.Instance.CurrentMoney.ToString()}";
    }

    public void ShowPhone()
    {
        if (isPhoneShown)
        {
            Destroy(phoneCache);
        }
        else
        {
            phoneCache = Instantiate(phonePrefab);
        }

        isPhoneShown = !isPhoneShown;
    }
}
