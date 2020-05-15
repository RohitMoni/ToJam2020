using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : Seating.SeatingManager
{
    private void Start()
    {
        foreach (FoodChoice choice in GetComponentsInChildren<FoodChoice>())
        {
            choice.manager = this;
        }
    }

    public void RecordFoodToGlobalState()
    {
        DinnerPartyGlobals partyGlobals = FindObjectOfType<DinnerPartyGlobals>();

        var foodArrangement = new _2020Vision.FoodArrangement
        {
            food = new List<_2020Vision.Food>()
        };

        var contributionArrangement = new _2020Vision.ContributionArrangement
        {
            contributions = new List<_2020Vision.Contribution>()
        };

        var choices = GetComponentsInChildren<FoodChoice>();

        foreach(var foodChoice in choices)
        {
            foodChoice.CreateContribution();
            foodArrangement.food.Add(foodChoice.food);
            contributionArrangement.contributions.Add(foodChoice.contribution);
        }

        partyGlobals.currentPartyState.foodArrangement = foodArrangement;
        partyGlobals.currentPartyState.contributionArrangement = contributionArrangement;
    }
}
