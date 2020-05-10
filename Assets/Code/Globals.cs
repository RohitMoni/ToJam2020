using _2020Vision;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    [HideInInspector]
    public PartyState currentPartyState;

    // Hard coded desired state for one scenario. This will need to be removed if we do multiple scenarios / generated scenarios
    public List<IRequirement> requirements = new List<IRequirement>()
    {
        new SeatedNextToRequirement() {
            Value = 10,
            PersonA = new Person(2),
            PersonB = new Person(0),
        },
        new SeatedNextToRequirement() {
            Value = 10,
            PersonA = new Person(3),
            PersonB = new Person(4),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            PersonA = new Person(1),
            PersonB = new Person(3),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            PersonA = new Person(5),
            PersonB = new Person(2),
        },
        new ContributionRequirement()
        {
            Value = 10,
            requiredContribution = new Contribution()
            {
                person = new Person(1),
                food = new Food()
                {
                    course = FoodCourse.Dessert
                }
            }
        },
        new ContributionRequirement()
        {
            Value = 10,
            requiredContribution = new Contribution()
            {
                person = new Person(2),
                food = new Food()
                {
                    course = FoodCourse.Appetizer
                }
            }
        },
        new ContributionRequirement()
        {
            Value = 10,
            requiredContribution = new Contribution()
            {
                person = new Person(3),
                food = new Food()
                {
                    course = FoodCourse.Cutlery
                }
            }
        },
        new ContributionRequirement()
        {
            Value = 10,
            requiredContribution = new Contribution()
            {
                person = new Person(4),
                food = new Food()
                {
                    course = FoodCourse.Drinks
                }
            }
        },
        new ContributionRequirement()
        {
            Value = 10,
            requiredContribution = new Contribution()
            {
                person = new Person(5),
                food = new Food()
                {
                    course = FoodCourse.Main
                }
            }
        },
        new TotalFoodRequirement()
        {
            Value = 10,
            requiredFood = new FoodArrangement()
            {
                food = new List<Food>()
                {
                    new Food()
                    {
                        course = FoodCourse.Appetizer
                    },
                    new Food()
                    {
                        course = FoodCourse.Main
                    },
                    new Food()
                    {
                        course = FoodCourse.Dessert
                    },
                    new Food()
                    {
                        course = FoodCourse.Drinks
                    },
                    new Food()
                    {
                        course = FoodCourse.Cutlery
                    },
                }
            }
        }
    };

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }
}
