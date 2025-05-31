using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public static class Validation
    {
        #region Номенклатурный номер
        public static bool IsNomenclatureNumberValid(string nomenclatureNumber)
        {
            if (string.IsNullOrEmpty(nomenclatureNumber) || nomenclatureNumber.Length != 9)
            {
                NotificationService.Notify("Предупреждение", "Номенклатурный номер должен содержать 9 цифр.", ToolTipIcon.Warning);
                return false;
            }

            if (!nomenclatureNumber.All(char.IsDigit))
            {
                NotificationService.Notify("Предупреждение", "Номенклатурный номер должен состоять только из цифр.", ToolTipIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool IsNomenclatureNumberExist(string nomenclatureNumber, TOOLACCOUNTINGDataSet toolAccounting)
        {
            bool isReturn;
            isReturn = toolAccounting.Nomenclature.Any(s => s.NomenclatureNumber == nomenclatureNumber);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Инструмента с таким номенклатурным номером не существует.", ToolTipIcon.Warning);
            return isReturn;
        }
        #endregion

        #region ИНН
        public static bool IsINNValid(string inn)
        {
            //return (inn.Length == 10 || inn.Length == 12) && inn.All(char.IsDigit);

            // Проверка на null, пустую строку и длину
            if (string.IsNullOrEmpty(inn) || !(inn.Length == 10 || inn.Length == 12))
            {
                NotificationService.Notify("Предупреждение", "ИНН должен содержать 10 цифр (для юридических лиц) или 12 цифр (для физических лиц и индивидуальных предпринимателей).", ToolTipIcon.Warning);
                return false;
            }

            // Проверка, что все символы — цифры
            if (!inn.All(char.IsDigit))
            {
                NotificationService.Notify("Предупреждение", "ИНН должен состоять только из цифр.", ToolTipIcon.Warning);
                return false;
            }
            if (inn.Length == 10)
            {
                int[] coefficients = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
                int controlSum = CalculateControlSum(inn, coefficients) % 11 % 10;

                if (controlSum != inn[9].ToInt())
                    NotificationService.Notify("Предупреждение", "ИНН не корректен. Не совпадает контрольная сумма.", ToolTipIcon.Warning);

                return controlSum == inn[9].ToInt();
            }

            // Проверка контрольных сумм для ИНН физ. лиц и ИП (12 цифр)
            if (inn.Length == 12)
            {
                // Проверка первой контрольной суммы (11-я цифра)
                int[] coefficients1 = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
                int controlSum1 = CalculateControlSum(inn, coefficients1) % 11 % 10;
                bool isValid1 = controlSum1 == inn[10].ToInt();

                // Проверка второй контрольной суммы (12-я цифра)
                int[] coefficients2 = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
                int controlSum2 = CalculateControlSum(inn, coefficients2) % 11 % 10;
                bool isValid2 = controlSum2 == inn[11].ToInt();

                if (!(isValid1 && isValid2))
                    NotificationService.Notify("Предупреждение", "ИНН не корректен. Не совпадает контрольная сумма.", ToolTipIcon.Warning);

                return isValid1 && isValid2;
            }

            return false;
        }
        // Вспомогательный метод для расчета контрольной суммы
        private static int CalculateControlSum(string inn, int[] coefficients)
        {
            int sum = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                sum += inn[i].ToInt() * coefficients[i];
            }
            return sum;
        }
        // Расширение для преобразования char в int
        private static int ToInt(this char c) => c - '0';

        public static bool IsINNUnique(string inn, TOOLACCOUNTINGDataSet toolAccounting, FormMode mode, TOOLACCOUNTINGDataSet.SuppliersRow originRow = null)
        {
            bool isReturn;
            if (mode == FormMode.Edit && inn == originRow.INN)
            {
                isReturn = true;
                return isReturn;
            }

            isReturn = !toolAccounting.Suppliers.Any(s => s.INN == inn);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Поставщик с таким ИНН уже существует.", ToolTipIcon.Warning);
            return isReturn;
        }
        #endregion

        #region Группа
        public static bool IsRangeValid(string range)
        {
            if (string.IsNullOrEmpty(range) || range.Length != 4)
            {
                NotificationService.Notify("Предупреждение", "Диапазон должен содержать 4 цифры.", ToolTipIcon.Warning);
                return false;
            }

            if (!range.All(char.IsDigit))
            {
                NotificationService.Notify("Предупреждение", "Диапазон должен состоять только из цифр.", ToolTipIcon.Warning);
                return false;
            }

            return true;
        }

        public static bool IsRangeUnique(string range, TOOLACCOUNTINGDataSet toolAccounting, FormMode mode, TOOLACCOUNTINGDataSet.GroupsRow originRow = null)
        {
            bool isReturn;
            if (mode == FormMode.Edit && range == originRow.RangeStart)
            {
                isReturn = true;
                return isReturn;
            }
            isReturn = !toolAccounting.Groups.Any(s => s.RangeStart == range);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Группа с таким дипазоном уже существует.", ToolTipIcon.Warning);
            return isReturn;
        }
        #endregion

    }
}
