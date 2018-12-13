using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Interfaces;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using Microsoft.EntityFrameworkCore;
namespace ThuongMaiDienTuAPI.Services
{
    public class PageService : IPageService
    {
        private DataContext db;
        public PageService(DataContext db)
        {
            this.db = db;
        }
        public async Task<object> Get(PageQuery query)
        {
            var pages = Sorting<Page>.Get(Filtering(db.Page, query), query);
            return new {
                Total = pages.Count(),
                Content = await Paging<Page>.Get(pages, query).ToListAsync()
            };
        }
        private IQueryable<Page> Filtering(IQueryable<Page> pages,PageQuery query)
        {
            if (query.TenPage != null)
            {
                pages = from x in pages
                        where x.Ten.Contains(query.TenPage)
                        select x;
            }

            return pages;
        }
    }
}
