using EasyUtilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUtilities.Helper;
public static class NextDueDateCalculator
{
    /// <summary>
    /// Calculates the next due date for a regular event.
    /// </summary>
    /// <param name="initialDate">The first occurence of the event.</param>
    /// <param name="referenceDate">The reference day, often today.</param>
    /// <param name="frequency">The frequency (e.g. weekly, monthly, quaterly, halfyearly, yearly). </param>
    /// <param name="factor">A optional factor to implement something like every third week (factor = 3).</param>
    /// <returns>Returns the DateOnly object of the next due date.</returns>
    public static DateOnly GetNextDueDate(DateOnly initialDate, DateOnly referenceDate, eFrequency frequency, int factor = 1)
    {
        var nextDuty = DateOnly.FromDateTime(DateTime.Now);

        if (initialDate >= referenceDate)
            return initialDate;

        switch (frequency)
        {
            case eFrequency.Daily:
                nextDuty = __GetNextDailyDueDate(initialDate, referenceDate, factor);
                break;
            case eFrequency.Weekly:
                nextDuty = __GetNextWeeklyDueDate(initialDate, referenceDate, factor);
                break;
            case eFrequency.EverySecondWeek:
                nextDuty = __GetNextWeeklyDueDate(initialDate, referenceDate, factor * 2);
                break;
            case eFrequency.Monthly:
                nextDuty = __GetNextMonthlyDueDate(initialDate, referenceDate, frequency, factor);
                break;
            case eFrequency.Quaterly:
                nextDuty = __GetNextMonthlyDueDate(initialDate, referenceDate, frequency, factor * 3);
                break;
            case eFrequency.HalfYearly:
                nextDuty = __GetNextMonthlyDueDate(initialDate, referenceDate, frequency, factor * 6);
                break;
            case eFrequency.Yearly:
                nextDuty = __GetNextMonthlyDueDate(initialDate, referenceDate, frequency, factor * 12);
                break;
        }
        return nextDuty;
    }

    /// <summary>
    /// Calculates the next due date for a daily occurence.
    /// </summary>
    /// <param name="initialDate">The first occurence of the event.</param>
    /// <param name="referenceDate">The reference day, often today.</param>
    /// <param name="factor">A optional factor to implement something like every second day (factor = 2).</param>
    /// <returns>Returns the DateOnly object of the next due date.</returns>
    private static DateOnly __GetNextDailyDueDate(DateOnly initialDate, DateOnly referenceDate, int factor = 1)
    {
        var dayDiff = referenceDate.DayNumber - initialDate.DayNumber;
        var rest = dayDiff % factor;
        return referenceDate.AddDays(factor > 1 ? factor - rest : 0);
    }

    //// <summary>
    /// Calculates the next due date for a weekly occurence.
    /// </summary>
    /// <param name="initialDate">The first occurence of the event.</param>
    /// <param name="referenceDate">The reference day, often today.</param>
    /// <param name="factor">A optional factor to implement something like every second week (factor = 2).</param>
    /// <returns>Returns the DateOnly object of the next due date.</returns>
    private static DateOnly __GetNextWeeklyDueDate(DateOnly initialDate, DateOnly referenceDate, int factor = 1)
    {
        var dayDiff = referenceDate.DayNumber - initialDate.DayNumber;

        var rest = dayDiff % 7;
        var weeks = dayDiff / 7;
        var weekRest = weeks % factor;

        if (rest == 0)
        {
            if (weekRest == 0)
                return referenceDate;
            else
                return referenceDate.AddDays(7 * (factor - weekRest));
        }
        else
        {
            var nextDuty = referenceDate.AddDays(7 - rest);

            if (factor > 1)
            {
                weeks = (nextDuty.DayNumber - initialDate.DayNumber) / 7;
                weekRest = weeks % factor;
            }

            if (weekRest == 0) //If InitDate is in First Period
                return nextDuty;

            return nextDuty.AddDays(7 * (factor - weekRest));
        }
    }

    /// <summary>
    /// Calculates the next due date for a monthly occurence.
    /// </summary>
    /// <param name="initialDate">The first occurence of the event.</param>
    /// <param name="referenceDate">The reference day, often today.</param>
    /// <param name="factor">A optional factor to implement something like every second month (factor = 2).</param>
    /// <returns>Returns the DateOnly object of the next due date.</returns>
    private static DateOnly __GetNextMonthlyDueDate(DateOnly initialDate, DateOnly referenceDate, eFrequency frequency,int factor = 1)
    {
        var initDay = initialDate.Day;
        var fromDay = referenceDate.Day;
        if (initDay == fromDay)
            return referenceDate;


        var monthsBetween = __CountMonthsBetween(referenceDate, initialDate);
        var monthRest = monthsBetween == 0 ? factor : monthsBetween % factor;

        if (monthRest < 0)
            throw new Exception("Month rest cannot be less than zero, please check");
        else if (monthRest == 0)
        {
            if (initDay < fromDay)
                referenceDate = __IncrementMonth(referenceDate, factor);
        }
        else if (monthRest != 0)
            referenceDate = __IncrementMonth(referenceDate, monthsBetween == 0 ? monthRest : factor - monthRest);

        var maxDaysForDateFrom = DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month);
        if (initDay <= maxDaysForDateFrom)
            return new DateOnly(referenceDate.Year, referenceDate.Month, initDay);
        else
            return new DateOnly(referenceDate.Year, frequency == eFrequency.Yearly ? initialDate.Month : referenceDate.Month, maxDaysForDateFrom);
    }

    /// <summary>
    /// Increments the month.
    /// </summary>
    /// <param name="referenceDate">The reference day, often today.</param>
    /// <param name="factor">The factor.</param>
    /// <returns>The DateOnly object with the incremented month.</returns>
    private static DateOnly __IncrementMonth(DateOnly referenceDate, int factor)
    {
        var newMonth = referenceDate.Month + factor;
        var newYear = referenceDate.Year;
        while (newMonth > 12)
        {
            newYear++;
            newMonth -= 12;
        }
        var maxDay = DateTime.DaysInMonth(newYear, newMonth);
        return new DateOnly(newYear, newMonth, referenceDate.Day >= maxDay ? maxDay : referenceDate.Day);
    }

    /// <summary>
    /// Counts the months between two DateOnly objects.
    /// </summary>
    /// <param name="dateOne">Date one.</param>
    /// <param name="dateTwo">Date two.</param>
    /// <returns>The months between the objects.</returns>
    private static int __CountMonthsBetween(DateOnly dateOne, DateOnly dateTwo)
    {
        if (dateOne == dateTwo)
            return 0;

        int months;
        if (dateOne > dateTwo)
        {
            if (dateOne.Year != dateTwo.Year)
                months = (12 - dateTwo.Month) + dateOne.Month;
            else
                return dateOne.Month - dateTwo.Month;

            months += (dateOne.Year - (dateTwo.Year + 1)) * 12;
        }
        else
        {
            if (dateOne.Year != dateTwo.Year)
                months = (12 - dateOne.Month) + dateTwo.Month;
            else
                return dateTwo.Month - dateOne.Month;
            months += (dateTwo.Year - (dateOne.Year + 1)) * 12;
        }
        return months;
    }

}
