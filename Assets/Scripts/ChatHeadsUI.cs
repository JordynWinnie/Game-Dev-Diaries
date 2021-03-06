﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatHeadsUI : MonoBehaviour
{
    public Task currentTask;
    [SerializeField] private GameObject chatParent;
    [SerializeField] private Notification senderMessage;
    [SerializeField] private Notification replyMessage;
    [SerializeField] private Button agreeToHelp;
    

    public void ShowConvo()
    {
        foreach (Transform child in chatParent.transform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(true);

        foreach (var line in currentTask.chatBubbleConversation.lines)
        {
            if (line.Character.isOtherSpeaker)
            {
                var prefab = Instantiate(senderMessage, chatParent.transform);
                prefab.IconDisplay = line.Character.portrait;
                prefab.DescriptionDisplay = line.text;
                prefab.TitleDisplay = line.Character.characterName;
            }
            else
            {
                var prefab = Instantiate(replyMessage, chatParent.transform);
                prefab.DescriptionDisplay = line.text;
                prefab.TitleDisplay = "You";
            }
        }
    }

    public void AgreeToHelp()
    {
        var prefab = Instantiate(replyMessage, chatParent.transform);
        prefab.DescriptionDisplay = "Yea, sure!";
        prefab.TitleDisplay = "You";
        GameDynamicData.Instance.CurrentTasks.Add(currentTask);
        GameStaticData.Instance.Tasks.Remove(currentTask);
        DateTimeHUD.Instance.ShowQuestMenu(true);
    }

    public void GoBack()
    {
        gameObject.SetActive(false);
    }
}
