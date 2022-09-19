using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Base
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public static bool operator ==(Enumeration one, Enumeration two)
        {
            return one.Equals(two);
        }

        public static bool operator !=(Enumeration one, Enumeration two)
        {
            return !one.Equals(two);
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        public static T? GetByName<T>(string name) where T : Enumeration =>
             GetAll<T>().FirstOrDefault(x => x.Name == name);


    }
}
