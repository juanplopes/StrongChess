using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongChess.Model.Pieces
{
    public static class Rules
    {
        class Instances<T>
            where T : new()
        {
            public static T instance = new T();
        }

        public static T For<T>()
            where T : new()
        {
            return Instances<T>.instance;
        }
    }
}
