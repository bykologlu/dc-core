﻿namespace DC.Core.Data.Paging
{
    public interface IPaginate<T>
    {
        int From { get; }
        int Index { get; }
        int Size { get; }
        int Count { get; }
        int Pages { get; }
        List<T> Items { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
