﻿using System.Globalization;

namespace _0_Framework.Application
{
    public static class Tools
    {
        public static string[] MonthNames = { "حمل", "ثور", "جوزا", "سرطان", "اسد", "سنبله", "میزان", "عقرب", "قوس", "جدی", "دلو", "حوت" };
        public static string[] DayNames = { "شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
        public static string[] DayNamesG = { "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };


        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }
        public static string ToYearFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}";
        }
        public static string ToSerialNumber(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"#_{pc.GetYear(date)}{pc.GetMonth(date):00}{pc.GetDayOfMonth(date):00}{date.Hour:00}{date.Minute:00}{date.Second:00}";
        }
        public static string ToHijri(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var hc = new HijriCalendar();
            return $"{hc.GetYear(date)}/{hc.GetMonth(date):00}/{hc.GetDayOfMonth(date):00}";
        }
        public static string ToDiscountFormat(this DateTime date)
        {
            if (date == new DateTime()) return "";
            return $"{date.Year}/{date.Month:00}/{date.Day:00}";
        }
        public static string ToIDCart(this DateTime date)
        {
            if (date == new DateTime()) return "";
            return $"{date.Year}{date.Month:00}{date.Day:00}";
        }
        public static string ToCartID(this DateTime date)
        {
            if (date == new DateTime()) return "";
            return $"{date.Year}{date.Month:00}{date.Day:00}{date.Hour:00}{date.Minute:00}{date.Second:00}";
        }
        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }
        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }
        private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static string ToEnglishNumber(this string strNum)
        {
            var cash = strNum;
            for (var i = 0; i < 10; i++)
                cash = cash.Replace(Pn[i], En[i]);
            return cash;
        }
        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(En[i], Pn[i]);
            return chash;
        }
        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var spited = InDate.Split('/');
            if (spited.Length < 3)
                return null;

            if (!int.TryParse(spited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(spited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(spited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            var day = Convert.ToInt32(persianDate.Substring(8, 2));
            try
            {
                return new DateTime(year, month, day, new PersianCalendar());
            }
            catch (Exception)
            {
                day -= 1;
                return new DateTime(year, month, day, new PersianCalendar());
            }
        }
        public static string ToMoney(this decimal myMoney)
        {
            return myMoney.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }
        public static string ToMoneyi(this int myMoney)
        {
            return myMoney.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }
        public static string ToMoneys(this string myMoney)
        {
            int Money = int.Parse(myMoney);
            return Money.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }
        public static string ToFileName(this DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
        }

        public static string ToDayFarsi(this DayOfWeek day)
        {
            Dictionary<string, string[]> DayOfWeeks = new Dictionary<string, string[]>();
            DayOfWeeks.Add("en", new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturaday" });
            DayOfWeeks.Add("fa", new string[] { "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" });
            return DayOfWeeks["fa"][(int)day];
        }
        public static string ToMonthFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            string persianDate = $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
            var month = Convert.ToInt32(persianDate.Substring(5, 2));
            string months = "";
            switch (month)
            {
                case 1:
                    months = "حمل";
                    break;
                case 2:
                    months = "ثور";
                    break;
                case 3:
                    months = "جوزا";
                    break;
                case 4:
                    months = "سرطان";
                    break;
                case 5:
                    months = "اسد";
                    break;
                case 6:
                    months = "سنبله";
                    break;
                case 7:
                    months = "میزان";
                    break;
                case 8:
                    months = "عقرب";
                    break;
                case 9:
                    months = "قوس";
                    break;
                case 10:
                    months = "جدی";
                    break;
                case 11:
                    months = "دلو";
                    break;
                case 12:
                    months = "حوت";
                    break;
            }
            return months.ToString();
        }
        public static string ToMonth(this int Month)
        {
            int month = Month;
            string months = "";
            switch (month)
            {
                case 1:
                    months = "حمل";
                    break;
                case 2:
                    months = "ثور";
                    break;
                case 3:
                    months = "جوزا";
                    break;
                case 4:
                    months = "سرطان";
                    break;
                case 5:
                    months = "اسد";
                    break;
                case 6:
                    months = "سنبله";
                    break;
                case 7:
                    months = "میزان";
                    break;
                case 8:
                    months = "عقرب";
                    break;
                case 9:
                    months = "قوس";
                    break;
                case 10:
                    months = "جدی";
                    break;
                case 11:
                    months = "دلو";
                    break;
                case 12:
                    months = "حوت";
                    break;
            }
            return months.ToString();
        }
    }
}