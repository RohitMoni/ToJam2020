using _2020Vision;
using System.Collections.Generic;
using UnityEngine;

public class DinnerPartyGlobals : MonoBehaviour
{
    [HideInInspector]
    public PartyState currentPartyState;

    public List<Person> Persons = new List<Person>();
    public List<GameObject> Guests = new List<GameObject>();
    public Sprite GrannySprite;

    // Hard coded desired state for one scenario. This will need to be removed if we do multiple scenarios / generated scenarios
    public List<IRequirement> requirements = new List<IRequirement>()
    {
        new SeatedNextToRequirement() {
            Value = 10,
            FeedbackMessage = "2 complained the entire time about not getting to gush over the details of the wedding with Granny. Nobody enjoyed the reunion.",
            PersonA = new Person(2),
            PersonB = new Person(0),
        },
        new SeatedNextToRequirement() {
            Value = 10,
            FeedbackMessage = "3 yelled that the seating was wrong, and bugged the person sitting besides 4 till the two were together. People were super uncomfortable after that.",
            PersonA = new Person(3),
            PersonB = new Person(4),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            FeedbackMessage = "1, upon arriving late, noticed the seating arrangement had 3 besides them. Granny asked later in the evening why 1 never showed up.",
            PersonA = new Person(1),
            PersonB = new Person(3),
        },
        new SeatedAwayFromRequirement()
        {
            Value = 10,
            FeedbackMessage = "5 didn't even get a chance to talk with anyone, instead had to listen to 2's wedding plans instead. 5 nearly threw water in 2's face after a complaint was made that this wedding was going to cost too much. Specifically that this was the third wedding 2 had planned.",
            PersonA = new Person(5),
            PersonB = new Person(2),
        },
        new ContributionRequirement()
        {
            Value = 10,
            FeedbackMessage = "1 showed up just as dessert started, only to have a call shortly afterwards. 0 noticed that 1's dessert wasn't present, but couldn't mention it as 1 was constantly on the phone.",
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
            FeedbackMessage = "Even though 2 had ranted for hours about the three-layer bean dip, upon the beginning of the meal it was nowhere to be found. 2 blamed the lack of veggies for some reason.",
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
            FeedbackMessage = "Setting up the table before the meal, 3 seemingly forgot the cutlery that was promised.  Some joked about not giving 3 cutlery to prove their point that 3 needed to learn to remember things.",
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
            FeedbackMessage = "Even though 4 was so excited about bringing drinks, upon arrival all of 4's drinks were empty.  4 apologized while hiccupping to roaring laughter.",
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
            FeedbackMessage = "Unfortunately, 5 wasn't able to bring the special turkey.  Some breathed a sigh of relief that they wouldn't have to try it, others furious that they didn't.",
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
            FeedbackMessage = "???",
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

    private void Start()
    {
        GameObject guest0 = GuestGenerator.Singleton.CreateGuest();
        Seating.Guest granny = guest0.GetComponent<Seating.Guest>();
        granny.Head.sprite = GrannySprite;
        granny.Eyes.sprite = null;
        granny.Hair.sprite = null;
        granny.Mouth.sprite = null;
        Person person0 = new Person(0)
        {
            name = "Granny"
        };
        Guests.Add(guest0);
        Persons.Add(person0);
        DontDestroyOnLoad(guest0);

        GameObject guest1 = GuestGenerator.Singleton.CreateGuest();
        Person person1 = new Person(1)
        {
            name = guest1.GetComponent<Seating.Guest>().GetName()
        };
        Guests.Add(guest1);
        Persons.Add(person1);
        DontDestroyOnLoad(guest1);

        GameObject guest2 = GuestGenerator.Singleton.CreateGuest();
        Person person2 = new Person(2)
        {
            name = guest2.GetComponent<Seating.Guest>().GetName()
        };
        Guests.Add(guest2);
        Persons.Add(person2);
        DontDestroyOnLoad(guest2);

        GameObject guest3 = GuestGenerator.Singleton.CreateGuest();
        Person person3 = new Person(3)
        {
            name = guest3.GetComponent<Seating.Guest>().GetName()
        };
        Guests.Add(guest3);
        Persons.Add(person3);
        DontDestroyOnLoad(guest3);

        GameObject guest4 = GuestGenerator.Singleton.CreateGuest();
        Person person4 = new Person(4)
        {
            name = guest4.GetComponent<Seating.Guest>().GetName()
        };
        Guests.Add(guest4);
        Persons.Add(person4);
        DontDestroyOnLoad(guest4);

        GameObject guest5 = GuestGenerator.Singleton.CreateGuest();
        Person person5 = new Person(5)
        {
            name = guest5.GetComponent<Seating.Guest>().GetName()
        };
        Guests.Add(guest5);
        Persons.Add(person5);
        DontDestroyOnLoad(guest5);
    }
}
