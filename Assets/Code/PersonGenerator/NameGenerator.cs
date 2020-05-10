using System;
using System.Collections.Generic;

namespace _2020Vision
{
    //Class for getting a random name for a person.
    public static class NameGenerator
    {
        private static readonly List<string> MascNames40s = new List<string>
        {
            "Donald",
            "Dwight",
            "Charles",
            "Ben",
            "Logan",
            "Ronald",
            "Michael",
            "David"
        };

        private static readonly List<string> FemmeNames40s = new List<string>
        {
            "Leana",
            "Barbara",
            "Patricia",
            "Carol",
            "Judith",
            "Betty",
            "Nancy",
            "Maria"
        };

        private static readonly List<string> MascNames50s = new List<string>
        {
            "John",
            "Charles",
            "Robert",
            "William",
            "Thomas",
            "Gary",
            "Steven"
        };

        private static readonly List<string> FemmeNames50s = new List<string>
        {
            "Linda",
            "Mary",
            "Sandra",
            "Deborah",
            "Kathleen",
            "Karen",
            "Nancy",
            "Lorraine",
            "Donna"
        };

        private static readonly List<string> MascNames60s = new List<string>
        {
            "Greg",
            "Derrick",
            "Robert",
            "Kenneth",
            "Jeffrey",
            "Kevin",
            "Mark"
        };

        private static readonly List<string> FemmeNames60s = new List<string>
        {
            "Debra",
            "Brenda",
            "Lisa",
            "Cynthia",
            "Sheena",
            "Maisie",
            "Kimberly",
            "Elizabeth",
            "Angela"
        };

        private static readonly List<string> MascNames70s = new List<string>
        {
            "Christopher",
            "Matthew",
            "Daniel",
            "Brian",
            "Scott",
            "Jason",
            "Mark",
            "Richard"
        };

        private static readonly List<string> FemmeNames70s = new List<string>
        {
            "Jennifer",
            "Michelle",
            "Kimberly",
            "Amy",
            "Tammy",
            "Stephanie",
            "Heather",
            "Nicole",
            "Melissa"
        };

        private static readonly List<string> MascNames80s = new List<string>
        {
            "Joshua",
            "Matthew",
            "Daniel",
            "David",
            "Justin",
            "Andrew",
            "Robert",
            "Christopher"
        };

        private static readonly List<string> FemmeNames80s = new List<string>
        {
            "Brittany",
            "Amanda",
            "Sarah",
            "Crystal",
            "Laura",
            "Danielle",
            "April",
            "Lindsey",
            "Katie"
        };

        private static readonly List<string> MascNames90s = new List<string>
        {
            "Joshua",
            "Tyler",
            "Andrew",
            "Brandon",
            "Nicholas",
            "Austin",
            "David",
            "James"
        };

        private static readonly List<string> FemmeNames90s = new List<string>
        {
            "Taylor",
            "Alexis",
            "Samantha",
            "Emily",
            "Ashley",
            "Lauren",
            "Megan",
            "Elizabeth",
            "Madison"
        };
    
        public enum AgeRange
        {
            Forties,
            Fifties,
            Sixties,
            Seventies,
            Eighties,
            Nineties,
            DontCare
        }

        public enum Gender
        {
            Masculine,
            Feminine,
            DontCare
        }

        private static Random rnGenerator = new Random();

        //Gets a random name from the various lists.
        public static string GenerateName(AgeRange ageRange = AgeRange.DontCare, Gender gender = Gender.DontCare)
        {
            List<string> PossibleNames = new List<string>(10);

            switch (ageRange)
            {
                case AgeRange.Forties:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames40s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames40s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames40s);
                                PossibleNames.AddRange(FemmeNames40s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.Fifties:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames50s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames50s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames50s);
                                PossibleNames.AddRange(FemmeNames50s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.Sixties:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames60s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames60s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames60s);
                                PossibleNames.AddRange(FemmeNames60s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.Seventies:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames70s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames70s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames70s);
                                PossibleNames.AddRange(FemmeNames70s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.Eighties:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames80s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames80s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames80s);
                                PossibleNames.AddRange(FemmeNames80s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.Nineties:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames90s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames90s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames90s);
                                PossibleNames.AddRange(FemmeNames90s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case AgeRange.DontCare:
                    {
                        switch (gender)
                        {
                            case Gender.Masculine:
                                PossibleNames.AddRange(MascNames40s);
                                PossibleNames.AddRange(MascNames50s);
                                PossibleNames.AddRange(MascNames60s);
                                PossibleNames.AddRange(MascNames70s);
                                PossibleNames.AddRange(MascNames80s);
                                PossibleNames.AddRange(MascNames90s);
                                break;
                            case Gender.Feminine:
                                PossibleNames.AddRange(FemmeNames40s);
                                PossibleNames.AddRange(FemmeNames50s);
                                PossibleNames.AddRange(FemmeNames60s);
                                PossibleNames.AddRange(FemmeNames70s);
                                PossibleNames.AddRange(FemmeNames80s);
                                PossibleNames.AddRange(FemmeNames90s);
                                break;
                            case Gender.DontCare:
                                PossibleNames.AddRange(MascNames40s);
                                PossibleNames.AddRange(MascNames50s);
                                PossibleNames.AddRange(MascNames60s);
                                PossibleNames.AddRange(MascNames70s);
                                PossibleNames.AddRange(MascNames80s);
                                PossibleNames.AddRange(MascNames90s);
                                PossibleNames.AddRange(FemmeNames40s);
                                PossibleNames.AddRange(FemmeNames50s);
                                PossibleNames.AddRange(FemmeNames60s);
                                PossibleNames.AddRange(FemmeNames70s);
                                PossibleNames.AddRange(FemmeNames80s);
                                PossibleNames.AddRange(FemmeNames90s);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
            }

            int index = rnGenerator.Next(PossibleNames.Count);
            return PossibleNames[index];
        }
    }
}