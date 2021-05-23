namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family() : this(new List<Person>())
        {
        }

        public Family(List<Person> familyList)
        {
            this.familyList = familyList;
        }

        private List<Person> familyList;

        public List<Person> FamilyList
        {
            get => this.familyList;
            set => this.familyList = value;
        }

        public void AddMember(Person member)
        {
            this.FamilyList.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.FamilyList
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
    }
}