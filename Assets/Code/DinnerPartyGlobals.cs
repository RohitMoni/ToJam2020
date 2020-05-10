using _2020Vision;
using System.Collections.Generic;
using UnityEngine;

public class DinnerPartyGlobals : MonoBehaviour
{
    [HideInInspector]
    public PartyState currentPartyState;

    public List<Person> guests = new List<Person>();

    // Hard coded desired state for one scenario. This will need to be removed if we do multiple scenarios / generated scenarios
    public List<IRequirement> requirements = new List<IRequirement>()
    {
        new SeatedNextToRequirement() {
            Value = 10,
            FeedbackMessage = "Relative 3 complained the entire time about not getting to gush over the details of the wedding with Granny.  Nobody enjoyed the reunion.",
            PersonA = new Person(2),
            PersonB = new Person(0),
        },
        new SeatedNextToRequirement() {
            Value = 10,
            FeedbackMessage = "Relative 4 yelled that the seating was wrong, and bugged the person sitting besides Relative 5 til the two were together.  People were super uncomfortble after that.",
            PersonA = new Person(3),
            PersonB = new Person(4),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            FeedbackMessage = "Relative 2, upon arriving late, noticed the seating arrangement had them beside 4.  Granny asked later in the evening why Relative 2 never showed up.",
            PersonA = new Person(1),
            PersonB = new Person(3),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            FeedbackMessage = "Relative 6 didn't even get a chance to talk with anyone, instead had to listen to Relative 3's wedding plans instead.  Relative 6 nearly threw water in Relative 3's face after a complaint was made that this wedding was going to cost too much. Specifically that this was the 3rd wedding Relative 3 had planned.",
            PersonA = new Person(5),
            PersonB = new Person(2),
        },
        new ContributionRequirement()
        {
            Value = 10,
            FeedbackMessage = "Relative 2 showed up just as dessert started, only to have a call shortly afterwards.  The dessert was nowhere to be found.",
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
            FeedbackMessage = "Even though Relative 3 had ranted for hours about their 3 layer bean dip, upon the beginning of the meal it was nowhere to be found. Relative 3 blamed the lack of veggies for some reason.",
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
            FeedbackMessage = "Somehow, with so little to bring, Relative 4 couldn't even come through to bring the cutlery.  You were only able to salvage this by quickly buying plastic forks.  Relative 4 broke theirs instantly.",
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
            FeedbackMessage = "Relative 5 brought drinks, but didn't seem to realize that drinks were supposed to be for everyone, not just for Relative 5. Everyone got to drink water.",
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
            FeedbackMessage = "Unfortunately, Relative 6 wasn't able to bring their special turkey, so there wasn't any main dish for the reunion.  Some breathed a sigh of relief that they wouldn't have to try it, others furious that they didn't.",
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
