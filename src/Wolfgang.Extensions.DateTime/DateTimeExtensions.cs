using System;
using System.Globalization;

namespace Wolfgang.Extensions.DateTime;


/// <summary>
/// A collection of extension methods for DateTime
/// </summary>
public static class DateTimeExtensions
{

    /// <summary>
    /// Remove the milliseconds and everything after the milliseconds
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime equal to the passed in value without milliseconds</returns>
    public static System.DateTime TruncateMilliseconds(this System.DateTime dateTime)
        => new
            (
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hour,
                dateTime.Minute,
                dateTime.Second,
                0,
                dateTime.Kind
            );



    /// <summary>
    /// Remove the seconds and everything after the seconds
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime equal to the passed in value without seconds and milliseconds</returns>
    public static System.DateTime TruncateSeconds(this System.DateTime dateTime)
        => new
            (
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hour,
                dateTime.Minute,
                0,
                0,
                dateTime.Kind
            );



    /// <summary>
    /// Returns a new DateTime that represents the first day of the
    /// month specified by the DateTime passed in.
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the first of the month.</returns>
    public static System.DateTime FirstOfMonth(this System.DateTime dateTime)
        => new
            (
                dateTime.Year,
                dateTime.Month,
                1,
                0,
                0,
                0,
                0,
                dateTime.Kind
            );



    /// <summary>
    /// Returns a new DateTime that represents the last day of the
    /// month specified by the DateTime passed in.
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the end of the month.</returns>
    public static System.DateTime EndOfMonth(this System.DateTime dateTime)
    {
        var firstOfMonth = dateTime.FirstOfMonth();

        return firstOfMonth.Month == 12 && firstOfMonth.Year == 9999
            ? new System.DateTime(System.DateTime.MaxValue.Ticks, dateTime.Kind)
            : firstOfMonth.AddMonths(1).AddTicks(-1);
    }




    /// <summary>
    /// Returns a new DateTime that represents the first day of the
    /// year specified by the DateTime passed in.
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the first of the year.</returns>
    public static System.DateTime FirstOfYear(this System.DateTime dateTime)
        => new
            (
                dateTime.Year,
                1,
                1,
                0,
                0,
                0,
                0,
                dateTime.Kind
            );



    /// <summary>
    /// Returns a new DateTime that represents the last day of the
    /// year specified by the DateTime passed in.
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the end of the year.</returns>
    public static System.DateTime EndOfYear(this System.DateTime dateTime)
    {
        var firstOfYear = dateTime.FirstOfYear();

        return firstOfYear.Year == 9999
            ? new System.DateTime(System.DateTime.MaxValue.Ticks, dateTime.Kind)
            : firstOfYear.AddYears(1).AddTicks(-1);
    }



    /// <summary>
    /// Returns a new DateTime that represents the first day of the
    /// week specified by the DateTime passed in using the thread's
    /// CurrentCulture FirstDayOfWeek 
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the first of the week.</returns>
    public static System.DateTime FirstOfWeek(this System.DateTime dateTime)
        => FirstOfWeek(dateTime, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);



    /// <summary>
    /// Returns a new DateTime that represents the first day of the
    /// week specified by the DateTime passed in using the specified
    /// firstDayOfWeek
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <param name="firstDayOfWeek">Specifies the first day of the week.</param>
    /// <returns>A new DateTime representing the first of the week.</returns>
    public static System.DateTime FirstOfWeek(this System.DateTime dateTime, DayOfWeek firstDayOfWeek)
    {
        var firstOfWeek = dateTime.Date;
        while (firstOfWeek.DayOfWeek != firstDayOfWeek)
        {
            if (firstOfWeek == System.DateTime.MinValue.Date)
            {
                return new System.DateTime(System.DateTime.MinValue.Ticks, dateTime.Kind);
            }

            firstOfWeek = firstOfWeek.AddDays(-1);
        }

        return new System.DateTime
        (
            firstOfWeek.Year,
            firstOfWeek.Month,
            firstOfWeek.Day,
            0,
            0,
            0,
            0,
            dateTime.Kind
        );
    }



    /// <summary>
    /// Returns a new DateTime that represents the last day of the
    /// week specified by the DateTime passed in using the thread's
    /// CurrentCulture FirstDayOfWeek 
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <returns>A new DateTime representing the end of the week.</returns>
    public static System.DateTime EndOfWeek(this System.DateTime dateTime)
        => EndOfWeek(dateTime, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);



    /// <summary>
    /// Returns a new DateTime that represents the last day of the
    /// week specified by the DateTime passed in using the specified
    /// firstDayOfWeek
    /// </summary>
    /// <param name="dateTime">The value to process.</param>
    /// <param name="firstDayOfWeek">Specifies the first day of the week. Default is Sunday.</param>
    /// <returns>A new DateTime representing the end of the week.</returns>
    public static System.DateTime EndOfWeek(this System.DateTime dateTime, DayOfWeek firstDayOfWeek)
    {
        var firstOfWeek = dateTime.FirstOfWeek(firstDayOfWeek);
        var maxTicks = System.DateTime.MaxValue.Ticks;
        var sevenDaysTicks = TimeSpan.FromDays(7).Ticks;

        return maxTicks - firstOfWeek.Ticks < sevenDaysTicks
            ? new System.DateTime(maxTicks, dateTime.Kind)
            : firstOfWeek.AddDays(7).AddTicks(-1);
    }
} 
