
using System;
using System.Collections.Generic;

namespace CaotunSpring002.Adapter
{
    /// <summary>
    /// State of grid filters.
    /// </summary>

    //public class ParameterFilters : IBaseFilters
    // public class BaseFilters : IBaseFilters
    //public class BaseFiltersV2 : IBaseFiltersV2
   // public class FiltersA000 : IFiltersA000
    public class FiltersV7 : IFiltersV7
    {
        //  private const int V = 10;

        /// <summary>
        /// Keep state of paging.
        /// </summary>
     //   public IPageHelperA000 PageHelper { get; set; }

        //public LocationFilters(IPageHelper pageHelper)
        public FiltersV7()

        {

            //PageHelper = pageHelper;

            // NOTE by Mark, 2021-01-14
            // 直接使用元件

            //PageHelper = new PageHelperA000();

            //PageHelper.PageSize = 10;
            //PageHelper.BaseUrl = "/base/"; // NOTE by Mark, 解決了可以共同  PageHelper, 可以各自定 PageSize 和 BaseUrl

       //     FieldMappers = GetFieldMapper.byEntityName("xxx");

            // NOTE by Mark, 2021-01-19, 基本功, 先設十組
            // 2021-01-24, TO 100
            FilterContains = new string[100];
            FilterContainsCol = new string[100];
            FilterContainsColName = new string[100];
            IsDev = false;
        }

        /// <summary>
        /// Avoid multiple concurrent requests.
        /// </summary>
       // public bool Loading { get; set; }


        /// <summary>
        /// Column to sort by.
        /// </summary>
       // public ApplicationFilterColumns SortColumn { get; set; }


        /// <summary>
        /// True when sorting ascending, otherwise sort descending.
        /// </summary>
       // public bool SortAscending { get; set; } = true;

        /// <summary>
        /// Column filtered text is against.
        /// </summary>
     //   public ApplicationFilterColumns FilterColumn { get; set; }



        public DateTime FilterDt1 { get; set; }
        public DateTime FilterDt2 { get; set; }

        /// <summary>
        /// Text to filter on.
        /// </summary>
        public string SortStr { get; set; }
        public string SortStr2 { get; set; }
        public string FilterText { get; set; }
        public string[] FilterContains { get; set; }
        public string[] FilterContainsCol { get; set; }
        public string[] FilterContainsColName { get; set; }


        //public string FilterLastName { get; set ; }

        public void MakeFieldMappers<T>( )
        {
            //https://stackoverflow.com/questions/10955579/passing-just-a-type-as-a-parameter-in-c-sharp
            Console.WriteLine("...doing MakeFieldMappers with T");
            Console.WriteLine(typeof(T));

        }
        public List<FieldMappingModel> FieldMappers { get; set; }
        public List<int> FMapper { get; set; }// for selected filter input
        public string WorkWith { get; set; }
        public string ErrMsg { get; set; }
        public bool IsDev { get; set; } = true;
        public int FILTER_FILED_CNT { get; set ; }
        //     public ApplicationFilterColumns DefaultColumn { get; set; }
        //   public AppSortType SortType { get; set; }

    }
}
