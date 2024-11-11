using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace _23Dh114228_MyStore.Models.ViewModel
{
    public class ProductSearchVM
    {  
        // tiêu chí để search theo tên , mô tả sản phẩm 
        // hoặc loại sản phẩm 
        public string SearchTerm { get; set; }

        // các tiêu chí để search theo giá 
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // thứ tự sắp xếp 
        public string SortOrder { get; set; }

        // Các thuộc tính hỗ trợ phân trang 
        public int PageNumber { get; set; } // Trang hiện tại 
        public int PageSize { get; set; } = 10; // Số sản phẩm mỗi trang 

        // danh sách sản phẩm nổi bật 
        public List<Product> FeaturedProducts { get; set; }

        // danh sách sản phẩm  mới đã phân trang 
        public PagedList.IPagedList<Product> Products { get; set; }

        //Danh sách sản phẩm thỏa thuận điều kiện tìm kiếm  
        //public List<Product> Products { get; set; }  

    }
}