using System;

//namespace CaotunSpring.C000.Adapter
namespace CaotunSpring002.Adapter
{
    public interface IAdapterV7
    {
        IFiltersV7 GetFilter();
      //  IFilters GetFilter();

        bool IsLoading { get; set; }
        string GetOrderBy();
        string GetSortString();
        string GetSortString2();
        string GetWhere();
        string GetWhereString();
        void Init(string PRE, Type type, string TABLE_CONFIG);
        void ReadJson(Type type, string PRE, string ENT);
    //    void Start(Type type, string PRE, string ENT, string TABLE_CONFIG);
        void UpdateFMapper(Type type);
        void WriteJson(string PRE, string ENT);
    }
}