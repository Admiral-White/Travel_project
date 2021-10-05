using System;
using Travel.Application.Commons.Interfaces;

namespace Travel.Shared.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}