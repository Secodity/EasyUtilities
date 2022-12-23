using EasyUtilities.Enums;
using EasyUtilities.Helper;

namespace EasyUtilities.Tests.Helper;

[TestClass]
public class NextDueDateCalculatorTests
{
	#region - GetNextDueDate -

	#region - Weekly -
	[TestMethod]
	public void TestOfGetNextDueDate_Weekly()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 21), eFrequency.Weekly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Weekly_YesterdayAsInitDate()
	{
		var expected = new DateOnly(2022, 12, 14);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.Weekly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Weekly_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.Weekly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfNextDueDate_Weekly_Today()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 21), new DateOnly(2022, 12, 21), eFrequency.Weekly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfNextDueDate_Weekly_Factor3()
	{
		var expected = new DateOnly(2023, 01, 03);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.Weekly, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfNextDueDate_Weekly_LongTimeAgo()
	{
		var expected = new DateOnly(1566, 06, 13);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(1376, 01, 01), new DateOnly(1566, 06, 12), eFrequency.Weekly);
		Assert.AreEqual(expected, actual);
	}
	#endregion

	#region - Daily -

	[TestMethod]
	public void TestOfGetNextDueDate_Daily()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 21), eFrequency.Daily);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Daily_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.Daily);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Daily_Today()
	{
		var expected = new DateOnly(2022, 12, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 21), new DateOnly(2022, 12, 28), eFrequency.Daily);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Daily_Factor3()
	{
		var expected = new DateOnly(2022, 12, 22);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.Daily, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Daily_LongTimeAgo()
	{
		var expected = new DateOnly(1566, 06, 12);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(1376, 01, 01), new DateOnly(1566, 06, 12), eFrequency.Daily);
		Assert.AreEqual(expected, actual);
	}
	#endregion

	#region - EverySecondWeek -

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 20), eFrequency.EverySecondWeek);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek_YesterdayInitDate()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 21), new DateOnly(2022, 12, 07), eFrequency.EverySecondWeek);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.EverySecondWeek);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek_Today()
	{
		var expected = new DateOnly(2022, 12, 21);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 21), eFrequency.EverySecondWeek);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek_Factor3()
	{
		var expected = new DateOnly(2023, 01, 24);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.EverySecondWeek, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_EverySecondWeek_ABitTimeAgo()
	{
		var expected = new DateOnly(2022, 12, 27);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 11, 29), new DateOnly(2022, 12, 14), eFrequency.EverySecondWeek);
		Assert.AreEqual(expected, actual);
	}

	#endregion

	#region - Monthly -

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 20), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_YesterdayInitDate()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_Today()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2023, 01, 07), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_Factor3()
	{
		var expected = new DateOnly(2023, 03, 13);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.Monthly, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_LongTimeAgo()
	{
		var expected = new DateOnly(1566, 07, 01);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(1376, 01, 01), new DateOnly(1566, 06, 12), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_ABitTimeAgo()
	{
		var expected = new DateOnly(2022, 12, 29);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 11, 29), new DateOnly(2022, 12, 14), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_MoreDaysThanNextMonth_LeapYear()
	{
		var expected = new DateOnly(2024, 02, 29);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2023, 01, 31), new DateOnly(2024, 02, 14), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_MoreDaysThanNextMonth_InitOnLeapYearDay()
	{
		var expected = new DateOnly(2024, 03, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 28), new DateOnly(2024, 03, 01), eFrequency.Monthly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Monthly_MoreDaysThanNextMonth_InitOnLeapYearDay_OnLeapDay_Factor12()
	{
		var expected = new DateOnly(2025, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 29), new DateOnly(2024, 03, 03), eFrequency.Monthly, 12);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
    public void TestOfRegularTransaction_Monthly_MoreDaysThanNextMonth_InitOnLeapYearDay_OnLeapDay_ThisMonth_Factor12()
    {
		var expected = new DateOnly(2025, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 29), new DateOnly(2025, 02, 01), eFrequency.Monthly, 12);
		Assert.AreEqual(expected, actual);
    }

	#endregion

	#region - Quaterly -

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly()
	{
		var expected = new DateOnly(2023, 03, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 20), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_YesterdayInitDate()
	{
		var expected = new DateOnly(2023, 03, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_Today()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2023, 01, 07), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_Factor3()
	{
		var expected = new DateOnly(2023, 09, 13);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.Quaterly, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_LongTimeAgo()
	{
		var expected = new DateOnly(1566, 07, 01);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(1376, 01, 01), new DateOnly(1566, 06, 12), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_MoreDaysThanNextMonth()
	{
		var expected = new DateOnly(2023, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 11, 29), new DateOnly(2022, 12, 14), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_ABitTimeAgo()
	{
		var expected = new DateOnly(2022, 04, 30);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 01, 31), new DateOnly(2022, 02, 14), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_MoreDaysThanNextMonth_LeapYear()
	{
		var expected = new DateOnly(2024, 04, 30);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2023, 01, 31), new DateOnly(2024, 02, 14), eFrequency.Quaterly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Quaterly_MoreDaysThanNextMonth_InitOnLeapYearDay_Factor12()
	{
		var expected = new DateOnly(2027, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 28), new DateOnly(2024, 03, 01), eFrequency.Quaterly, 12);
		Assert.AreEqual(expected, actual);
	}

	#endregion

	#region - HalfYearly -

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly()
	{
		var expected = new DateOnly(2023, 06, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 20), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_YesterdayInitDate()
	{
		var expected = new DateOnly(2023, 06, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099, 05, 06), new DateOnly(2022, 12, 21), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_Today()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2023, 01, 07), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_Factor3()
	{
		var expected = new DateOnly(2024, 06, 13);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.HalfYearly, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_MoreDaysThanNextMonth()
	{
		var expected = new DateOnly(2023, 05, 29);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 11, 29), new DateOnly(2022, 12, 14), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_ABitTimeAgo()
	{
		var expected = new DateOnly(2022, 07, 31);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 01, 31), new DateOnly(2022, 02, 14), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_MoreDaysThanNextMonth_LeapYear()
	{
		var expected = new DateOnly(2024, 07, 31);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2023, 01, 31), new DateOnly(2024, 02, 14), eFrequency.HalfYearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_HalfYearly_MoreDaysThanNextMonth_InitOnLeapYearDay_Factor12()
	{
		var expected = new DateOnly(2030, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 28), new DateOnly(2024, 03, 01), eFrequency.HalfYearly, 12);
		Assert.AreEqual(expected, actual);
	}

	#endregion

	#region - Yearly -

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly()
	{
		var expected = new DateOnly(2023, 12, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_YesterdayInitDate()
	{
		var expected = new DateOnly(2023, 12, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2022, 12, 08), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_InitDateInFuture()
	{
		var expected = new DateOnly(2099, 05, 06);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2099,05,06), new DateOnly(2022, 12, 21), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_Today()
	{
		var expected = new DateOnly(2023, 01, 07);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 07), new DateOnly(2023, 01, 07), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_Factor3()
	{
		var expected = new DateOnly(2025, 12, 13);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 12, 13), new DateOnly(2022, 12, 21), eFrequency.Yearly, 3);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_MoreDaysThanNextMonth()
	{
		var expected = new DateOnly(2023, 11, 29);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 11, 29), new DateOnly(2022, 12, 14), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_ABitTimeAgo()
	{
		var expected = new DateOnly(2023, 01, 31);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2022, 01, 31), new DateOnly(2022, 02, 14), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_MoreDaysThanNextMonth_LeapYear()
	{
		var expected = new DateOnly(2025, 01, 31);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2023, 01, 31), new DateOnly(2024, 02, 14), eFrequency.Yearly);
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void TestOfGetNextDueDate_Yearly_MoreDaysThanNextMonth_InitOnLeapYearDay_Factor12()
	{
		var expected = new DateOnly(2036, 02, 28);
		var actual = NextDueDateCalculator.GetNextDueDate(new DateOnly(2024, 02, 28), new DateOnly(2024, 03, 01), eFrequency.Yearly, 12);
		Assert.AreEqual(expected, actual);
	}

	#endregion

	#endregion
}
