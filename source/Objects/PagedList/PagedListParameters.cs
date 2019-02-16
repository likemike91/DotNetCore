using System.Collections.Generic;

namespace DotNetCore.Objects
{
    public class PagedListParameters
    {
        public IList<Order> Orders { get; set; } = new List<Order>();

        public Page Page { get; set; } = new Page();
    }
}
