using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChoice : ItemSpot
{
    public _2020Vision.Food food;
    public _2020Vision.Person person { get => contribution.person; set => contribution.person = value; }

    public _2020Vision.Contribution contribution = new _2020Vision.Contribution();

    public void CreateContribution()
    {
        if(heldItem is Guest guest)
        {
            person = guest.person;
            contribution.food = food;
        }
    }
}
