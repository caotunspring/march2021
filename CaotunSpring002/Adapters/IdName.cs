
using System;
using System.Collections.Generic;



namespace CaotunSpring002.Adapter
{
    public partial class IdName
    {
        public IdName() { }
        public IdName(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}