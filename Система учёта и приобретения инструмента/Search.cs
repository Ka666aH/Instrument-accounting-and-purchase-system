using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учёта_и_приобретения_инструмента
{
    public class SearchParameter
    {
        public string Field { get; }
        public object Value { get; }
        public bool SearchFromStart { get; }

        public SearchParameter(string field, object value, bool searchFromStart = true)
        {
            Field = field;
            Value = value;
            SearchFromStart = searchFromStart;
        }
    }

    public class Search
    {
        public static string Filter(List<SearchParameter> parameters)
        {
            var conditions = new List<string>();

            foreach (var parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    string formattedValue;
                    string condition;
                    switch (parameter.Value)
                    {
                        case string strVal:
                            string pureStr = strVal.Replace("'", "''")
                                .Replace("%", "[%]")
                                .Replace("_", "[_]").Trim();
                            if (parameter.SearchFromStart) formattedValue = $"'{pureStr}%'";
                            else formattedValue = $"'%{pureStr}%'";
                            string formattedValueEN = ToEN(formattedValue);
                            string formattedValueRU = ToRU(formattedValue);
                            //condition = $"{parameter.Field} LIKE {formattedValue}";
                            condition = $"({parameter.Field} LIKE {formattedValue} OR {parameter.Field} LIKE {formattedValueEN} OR {parameter.Field} LIKE {formattedValueRU})";
                            break;

                        case DateTime dateVal:
                            if (dateVal.TimeOfDay == TimeSpan.Zero) formattedValue = $"'{dateVal:yyyy-MM-dd}'";
                            else formattedValue = $"'{dateVal:yyyy-MM-dd HH:mm:ss}'";
                            condition = $"{parameter.Field} = {formattedValue}";
                            break;

                        case bool boolVal:
                            formattedValue = boolVal ? "1" : "0";
                            condition = $"{parameter.Field} = {formattedValue}";
                            break;

                        case decimal decimalVal:
                            formattedValue = decimalVal.ToString(CultureInfo.InvariantCulture);
                            //condition = $"CONVERT(VARCHAR(50), {parameter.Field}) LIKE '{formattedValue}%'";
                            condition = $"{parameter.Field} = {formattedValue}";
                            break;

                        case int intVal:
                        case long longVal:
                        case short shortVal:
                        case byte byteVal:
                            formattedValue = parameter.Value.ToString();
                            //condition = $"CONVERT(VARCHAR(50), {parameter.Field}) LIKE '{formattedValue}%'";
                            condition = $"{parameter.Field} = {formattedValue}";
                            break;

                        default:
                            throw new ArgumentException($"Неподдерживаемый тип данных: {parameter.Value.GetType()}");
                    }

                    //conditions.Add($"{parameter.Field} LIKE {formattedValue}");
                    conditions.Add(condition);
                }
            }
            return string.Join(" AND ", conditions);
        }
        public static string ToEN(string str)
        {
            return str
                .Replace("А", "A")
                .Replace("В", "B")
                .Replace("Е", "E")
                .Replace("К", "K")
                .Replace("М", "M")
                .Replace("Н", "H")
                .Replace("О", "O")
                .Replace("Р", "P")
                .Replace("С", "C")
                .Replace("Т", "T")
                .Replace("У", "Y")
                .Replace("Х", "X")

                .Replace("а", "a")
                .Replace("в", "b")
                .Replace("е", "e")
                .Replace("к", "k")
                .Replace("м", "m")
                .Replace("н", "h")
                .Replace("о", "o")
                .Replace("р", "p")
                .Replace("с", "c")
                .Replace("т", "t")
                .Replace("у", "y")
                .Replace("х", "x");
        }
        public static string ToRU(string str)
        {
            return str
                .Replace("A", "А")
                .Replace("B", "В")
                .Replace("E", "Е")
                .Replace("K", "К")
                .Replace("M", "М")
                .Replace("H", "Н")
                .Replace("O", "О")
                .Replace("P", "Р")
                .Replace("C", "С")
                .Replace("T", "Т")
                .Replace("Y", "У")
                .Replace("X", "Х")

                .Replace("a", "а")
                .Replace("b", "в")
                .Replace("e", "е")
                .Replace("k", "к")
                .Replace("m", "м")
                .Replace("h", "н")
                .Replace("o", "о")
                .Replace("p", "р")
                .Replace("c", "с")
                .Replace("t", "т")
                .Replace("y", "у")
                .Replace("x", "х");
        }
    }
}
