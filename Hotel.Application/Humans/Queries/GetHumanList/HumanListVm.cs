using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Humans.Queries.GetHumanList
{
    public class HumanListVm
    {
        public IList<HumanLookupDto> Humans { get; set; }
    }
}
