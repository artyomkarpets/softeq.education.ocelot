using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class UsersQuerySettings : BaseQuerySettings
    {
        public UsersQuerySettings(int skip, int take, string? email = null, string? name = null, string? surname = null) : base(skip, take)
        {
            Email = email;
            Name = name;
            Surname = surname;

        }

        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

    }
}
