using System.Collections.Generic;

namespace _2020Vision {

    public class Person
    {
        public string name;
    }

    public class Contribution
    {
        public Person person;
        public Food food;
    }

    // A contribution arrangement, including who is contributing what to the party
    public class ContributionArrangement
    {
        public List<Contribution> contributions;
    }
}