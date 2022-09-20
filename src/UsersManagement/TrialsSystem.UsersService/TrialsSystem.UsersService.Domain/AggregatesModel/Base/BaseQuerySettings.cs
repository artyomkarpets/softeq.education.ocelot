using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.Base
{
    public class BaseQuerySettings
    {
        public BaseQuerySettings(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }

    }
}
