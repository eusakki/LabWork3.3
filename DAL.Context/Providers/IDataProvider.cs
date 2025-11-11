using System;
using System.Collections.Generic;

namespace DAL.Providers
{
    public interface IDataProvider<T>
    {
        // Save collection of T to file
        void Save(IEnumerable<T> items, string filePath);
        // Load collection of T from file
        IEnumerable<T> Load(string filePath);
    }
}
