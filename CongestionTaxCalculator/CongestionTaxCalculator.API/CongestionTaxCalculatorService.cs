using CongestionTaxCalculator.API.Models;
using CongestionTaxCalculator.API.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionTaxCalculator.API
{
    public class CongestionTaxCalculatorService : ICongestionTaxCalculatorService
    {
        readonly ICongestionTaxCalculatorRepository _congestionTaxCalculatorRepository;
        public CongestionTaxCalculatorService(ICongestionTaxCalculatorRepository congestionTaxCalculatorRepository)
        {
            _congestionTaxCalculatorRepository = congestionTaxCalculatorRepository;
        }

        public int CalculateCongestionTax(DateTime date, string vehicle, string city, string serialNumber)
        {
            var cityTollRules = _congestionTaxCalculatorRepository.GetTollRules(city);

            if (IsToolFree(cityTollRules.TollFreeVehicles, vehicle, date) || )
            {
                return 0;
            }

            return GetTollFee(date, cityTollRules);
        }

        public int GetTollFee(DateTime date, CityTollRule cityTollRule)
        {
            foreach (var tollRule in cityTollRule.TollRules)
            {
                var timeFrom = DateTime.Parse(tollRule.TimeFrom).TimeOfDay;
                var timeTo = DateTime.Parse(tollRule.TimeTo).TimeOfDay;

                if (IsInTimeRange(date, timeFrom, timeTo))
                {
                    return tollRule.Cost;
                }
            }
            return 0;
        }

        public bool IsInTimeRange(DateTime date, TimeSpan start, TimeSpan end)
        {
            var timeNow = date.TimeOfDay;
            return start >= timeNow && timeNow <= end;
        }

        public bool IsTollFreeDate(DateTime date)
        {
            var trimmedDate = date.Date;
            //Checking for weekend first so we can ignore calculating it for every holiday
            if (trimmedDate.DayOfWeek == DayOfWeek.Saturday || trimmedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            //January got set dates for holidays
            if (trimmedDate.Month == 1 && (trimmedDate.Day == 1 || trimmedDate.Day == 5 || trimmedDate.Day == 6))
            {
                return true;
            }
            var easterDate = DateCalculator.GetFirstSundayOfNextMonth(new DateTime(trimmedDate.Year, 3, 1));
            //Easter in Sweden is always the first sunday of April. Friday and Thursday before that is a holiday so is monday after
            if (trimmedDate.Month == easterDate.Month && (trimmedDate.Day == easterDate.Day - 2 || trimmedDate.Day == easterDate.Day - 3 || trimmedDate.Day == easterDate.Day + 1))
            {
                return true;
            }
            //Walpurgis Night
            if (trimmedDate.Month == 4 && trimmedDate.Day == 30)
            {
                return true;
            }
            //First of may
            if(trimmedDate.Month == 1 && trimmedDate.Day == 1)
            {
                return true;
            }
            //Ascension Day
            if(trimmedDate == DateCalculator.GetAscensionDayDate(easterDate))
            {
                return true;
            }
            var pentecostDate = DateCalculator.GetPentecostDayDate(easterDate);
            if(trimmedDate == pentecostDate || trimmedDate == pentecostDate.AddDays(-1))
            {
                return true;
            }
            //Sweden's National Day
            if (trimmedDate.Month == 6 && trimmedDate.Day == 6)
            {
                return true;
            }
            var midsummerDate = DateCalculator.GetMidsummerDate(trimmedDate);
            if (trimmedDate == midsummerDate || trimmedDate == midsummerDate.AddDays(-1))
            {
                return true;
            }
            var allSaintsDay = DateCalculator.GetAllSaintsDayDate(trimmedDate);
            if(trimmedDate == allSaintsDay || trimmedDate == allSaintsDay.AddDays(-1))
            {
                return true;
            }
            //Christmas and new years
            if(trimmedDate.Month == 12 && (trimmedDate.Day == 24 || trimmedDate.Day == 25|| trimmedDate.Day == 26 || trimmedDate.Day == 31))
            {
                return true;
            }

            return false;
        }

        private bool IsToolFree(List<string> toolFreeVehicles, string vehicle, DateTime date, string serialNumber)
        {
            if (toolFreeVehicles.Contains(vehicle))
            {
                return true;
            }
            if(IsTollFreeDate(date))
            {
                return true;
            }
            if(IsVehicleTolled(date, serialNumber))
            {
                return true;
            }
            return false;
        }
        private bool IsVehicleTolled(DateTime date, string serialNumber)
        {
            var tolledVehicles = _congestionTaxCalculatorRepository.GetTolledVehicles();

            var vehicle = tolledVehicles.Vehicles.Where(x => x.SerialNumber == serialNumber).Select(x => new Vehicle
            {
                TolledDate = x.TolledDate,
                SerialNumber = x.SerialNumber
            }).FirstOrDefault();

            if (vehicle != null && vehicle.TolledDate.AddMinutes(60) > date)
            {
                return true;
            }
            else
            {
                var vehicleToBeTolled = new Vehicle
                {
                    SerialNumber = serialNumber,
                    TolledDate = date
                };

                _congestionTaxCalculatorRepository.SaveTolledVehicle(vehicleToBeTolled);
            }

            return false;
        }
    }
}
