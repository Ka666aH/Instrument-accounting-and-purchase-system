using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class AddMoving : Form
    {
        private void Add_CheckedChanged(object sender, EventArgs e)
        {
            if (Add.Checked)
            {
                StorageFrom.ReadOnly = true;
                StorageTo.ReadOnly = false;
                label15.Text = "Тип документа *";
                label7.Text = "Документ-основание *";
                label5.Text = "Склад-отправитель";
                SourceDocumentType.Text = null;
            } else
            {
                if (NonAdd.Checked)
                {
                    StorageFrom.ReadOnly = false;
                    StorageTo.Text = "12";
                    StorageTo.ReadOnly = true;
                    label15.Text = "Тип документа *";
                    label7.Text = "Документ-основание *";
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = "Дефектная ведомость";
                }
                else
                {
                    label15.Text = "Тип документа";
                    label7.Text = "Документ-основание";
                    StorageFrom.ReadOnly = false;
                    StorageTo.ReadOnly = false;
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = null;
                }
            }   
        }

        /// <summary>
        /// Предварительно заполняет форму перемещения.
        /// </summary>
        public void Prefill(string nomenNumber, int? storageFromId, string batchNumber, decimal price, bool setMoving = true, int? storageToId = null)
        {
            try
            {
                Nomenclature.Text = nomenNumber;
                if (storageFromId.HasValue)
                    StorageFrom.Text = storageFromId.Value.ToString();
                BatchNumber.Text = batchNumber;
                Price.Text = price.ToString("0.##");

                if (storageToId.HasValue)
                    StorageTo.Text = storageToId.Value.ToString();

                if (setMoving)
                {
                    Moving.Checked = true;
                }
            }
            catch { /* в случае ошибок просто игнорируем */ }
        }
    }
}
