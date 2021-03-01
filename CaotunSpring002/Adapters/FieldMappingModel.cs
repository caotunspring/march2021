
using System;
using System.Collections.Generic;



namespace CaotunSpring002.Adapter
{
    public partial class FieldMappingModel
    {
        public FieldMappingModel() { }
        public FieldMappingModel(string id, string name)
        {
            Id = id;
            Name = name;
            Index = -1;
            Ext = "";
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }
        public string Ext { get; set; }

    }
}