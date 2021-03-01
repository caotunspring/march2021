
using System;
using System.Collections.Generic;

namespace CaotunSpring002.Adapter
{
    /// <summary>
    /// Interface for filtering.
    /// </summary>
    //public interface IBaseFiltersV2
    public interface IFiltersV7
    {
        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being filtered on.
        /// </summary>
        //ApplicationFilterColumns FilterColumn { get; set; }

        //ApplicationFilterColumns DefaultColumn { get; set; }
        //AppSortType SortType { get; set; }
        string ErrMsg { get; set; }

        /// <summary>
        /// Loading indicator.
        /// </summary>
      //  bool Loading { get; set; }
        bool IsDev { get; set; }

        /// <summary>
        /// The text of the filter.
        /// </summary>

        DateTime FilterDt1 { get; set; }
        DateTime FilterDt2 { get; set; }
        int FILTER_FILED_CNT { get; set; }
     //   string WorkWith { get; set; } // to enforce this new IBaseFilter

        string FilterText { get; set; }

        string[] FilterContains { get; set; }
        string[] FilterContainsCol { get; set; }
        string[] FilterContainsColName { get; set; }

        void MakeFieldMappers<T>();
        List<FieldMappingModel> FieldMappers { get; set; }
        List<int> FMapper { get; set; }


        /// <summary>
        /// Paging state in <see cref="PageHelper"/>.
        /// </summary>
      //  IPageHelperA000 PageHelper { get; set; }


        /// <summary>
        /// Gets or sets a value indicating if the sort is ascending or descending.
        /// </summary>
     //   bool SortAscending { get; set; }
        string SortStr { get; set; }
        string SortStr2 { get; set; } // NOTE by Mark, 2021-01-22

        /// <summary>
        /// The <see cref="ContactFilterColumns"/> being sorted.
        /// </summary>
   //     ApplicationFilterColumns SortColumn { get; set; }
    }
}
