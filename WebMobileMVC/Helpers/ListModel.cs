using System;
using System.Collections.Generic;

namespace WebMobileMVC.Helpers
{
    public class ListModel<T>
    {
        public int Total { get; set; }
        public List<T> Content { get; set; } = new List<T>();
    }
}
