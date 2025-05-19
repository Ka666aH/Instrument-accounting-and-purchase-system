using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учёта_и_приобретения_инструмента
{
    public class Search
    {
        public static string Filter(Dictionary<string, object> parameters)
        {
            var conditions = new List<string>();

            foreach (var parameter in parameters)
            {
                if (parameter.Value != null)
                {
                    string formattedValue;

                    switch (parameter.Value)
                    {
                        case string strVal:
                            string pureStr = strVal.Replace("'", "''")
                                .Replace("%", "[%]")
                                .Replace("_", "[_]");
                            formattedValue = $"'{strVal}%'";
                            break;

                        case DateTime dateVal:
                            if (dateVal.TimeOfDay == TimeSpan.Zero) formattedValue = $"'{dateVal:yyyy-MM-dd}'";
                            else formattedValue = $"'{dateVal:yyyy-MM-dd HH:mm:ss}'";
                            break;

                        case bool boolVal:
                            formattedValue = boolVal ? "1" : "0";
                            break;

                        case decimal decimalVal:
                            formattedValue = decimalVal.ToString(CultureInfo.InvariantCulture);
                            break;

                        case int intVal:
                        case long longVal:
                        case short shortVal:
                        case byte byteVal:
                            formattedValue = parameter.Value.ToString();
                            break;

                        default:
                            throw new ArgumentException($"Неподдерживаемый тип данных: {parameter.Value.GetType()}");
                    }

                    conditions.Add($"{parameter.Key} LIKE {formattedValue}");
                }
            }
            return string.Join(" AND ", conditions);
        }
    }
}
