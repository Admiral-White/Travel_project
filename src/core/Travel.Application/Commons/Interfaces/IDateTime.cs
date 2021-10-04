using System;

namespace Travel.Application.Commons.Interfaces
{
    public interface IDateTime
    {
        DateTime NowUtc { get; }
    }
}