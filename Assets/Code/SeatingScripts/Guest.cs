﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class GuestData
{
    public int relative = -1;
    public Sprite  Head, Hair, Eyes, Mouth;
    public string name = "Blank";
}
public class Guest : Item
{
    public _2020Vision.Person person { get => new _2020Vision.Person(relative); }
    public Image Head;
    public Image Hair;
    public Image Eyes;
    public Image Mouth;
    public int relative;

    private string GuestName = "Unnamed";

    void Awake()
    {
        Head = transform.GetChild(0).GetComponent<Image>();
        Eyes = transform.GetChild(1).GetComponent<Image>();
        Mouth = transform.GetChild(2).GetComponent<Image>();
        Hair = transform.GetChild(3).GetComponent<Image>();
    }

    public void Setup(GuestData guest)
    {
        relative = guest.relative;
        GuestName = guest.name;
        Head.sprite = guest.Head;
        if (relative == 0)
        {
            Destroy(Eyes.gameObject);
            Destroy(Hair.gameObject);
            Destroy(Mouth.gameObject);
            return;
        }
        Hair.sprite = guest.Hair;
        Eyes.sprite = guest.Eyes;
        Mouth.sprite = guest.Mouth;
    }

    public void SetPortrait(Sprite head, int relativeIndex)
    {
        relative = relativeIndex;
        Head.sprite = head;
    }

    public void SetHair(Sprite hair)
    {
        Hair.sprite = hair;
    }

    public void SetEyes(Sprite eyes)
    {
        Eyes.sprite = eyes;
    }

    public void SetMouth(Sprite mouth)
    {
        Mouth.sprite = mouth;
    }

    public void SetName(string name)
    {
        GuestName = name;
    }

    public string GetName()
    {
        return GuestName;
    }

    public override void SeatGuest(Transform seatTransform)
    {
        base.SeatGuest(seatTransform);
        seatIndex = seatTransform.GetSiblingIndex();
    }
}