using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSource.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }

    public class PagedResultBase
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalItemCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }

        public string PageUrl { get; set; }
    }

    public class PageQuery
    {
        //public PageQuery(int? page = 1, int? pageSize = 10)
        //{
        //    Page = page >= 1 ? page.Value : 1;

        //    switch (pageSize)
        //    {
        //        case 5:
        //        case 15:
        //        case 20:
        //        case 30:
        //        case 40:
        //        case 50:
        //            PageSize = pageSize.Value;
        //            break;
        //        default:
        //            PageSize = 10;
        //            break;
        //    }
        //}

        //public int Page { get; set; }

        //public int PageSize { get; set; }

        private int _page;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value >= 1 ? value : 1;
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                switch (value)
                {
                    case 5:
                    case 15:
                    case 20:
                    case 30:
                    case 40:
                    case 50:
                        _pageSize = value;
                        break;
                    default:
                        _pageSize = 10;
                        break;
                }
            }
        }
    }
}