using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учёта_и_приобретения_инструмента
{
    public static class Validation
    {
        #region ИНН
        public static bool IsInnValid(string inn)
        {
            return (inn.Length == 10 || inn.Length == 12) && inn.All(char.IsDigit);
            //Стоит ли добавить проверку контрольной суммы ИНН?
        }

        public static bool IsINNUnique(string inn, TOOLACCOUNTINGDataSet toolAccounting, FormMode mode, TOOLACCOUNTINGDataSet.SuppliersRow originRow = null)
        {
            if (mode == FormMode.Edit && inn == originRow.INN) return true;
            return !toolAccounting.Suppliers.Any(s => s.INN == inn);
        }
        #endregion
    }
}
