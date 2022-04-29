using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Catalog
{
    public class GetExamplePagingRequest : PageQuery
    {
        public string ParamExample1 { get; set; }
        public string ParamExample2 { get; set; }

        //...
    }

    public class ExampleVm
    {
        public string Id { get; set; }
        public string Name { get; set; }

        //...
    }

    public class CreateExampleVm
    {
        public string Id { get; set; }
        public string Name { get; set; }

        //...
    }
}
