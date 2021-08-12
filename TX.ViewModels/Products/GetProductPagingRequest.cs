using System.Collections.Generic;
using TX.ViewModels.Common;

namespace TX.ViewModels.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public GetProductPagingRequest()
        {
            CategoryIds = new List<int>();
            if (PageIndex == 0)
                PageIndex = 1;
            if (PageSize == 0)
                PageSize = 10;
        }

        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}