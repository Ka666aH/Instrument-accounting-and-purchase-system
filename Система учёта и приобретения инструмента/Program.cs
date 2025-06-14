using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Система_учёта_и_приобретения_инструмента
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Глобальные обработчики исключений – чтобы ни один непойманный Exception не сорвал демонстрацию
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => HandleException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                if (ex != null) HandleException(ex);
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                HandleException(e.Exception);
                e.SetObserved();
            };

            //закрытие Excel процессов(не работает)
            //Application.ApplicationExit += (s, e) => CleanupExcel();

            Application.Run(new LoginForm());
        }

        /// <summary>
        /// Единая точка обработки исключений – пишет сообщение в Debug и показывает всплывающее уведомление.
        /// Никакие исключения не «проваливаются» наружу.
        /// </summary>
        private static void HandleException(Exception ex)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Unhandled: {ex}");
                NotificationService.Notify("Ошибка", ex.Message, ToolTipIcon.Warning);
            }
            catch { /* должно быть безопасно */ }
        }

        //    private static MSExcel.Application excelApp;
        //    private static void CleanupExcel()
        //    {
        //        try
        //        {
        //            // Получаем все процессы Excel перед закрытием
        //            var excelProcesses = Process.GetProcessesByName("EXCEL");

        //            // Закрываем все COM-объекты
        //            if (System.Runtime.InteropServices.Marshal.IsComObject(excelApp))
        //            {
        //                excelApp.Quit();
        //                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        //                excelApp = null;
        //            }

        //            // Принудительно закрываем оставшиеся процессы
        //            foreach (var process in excelProcesses)
        //            {
        //                if (!process.HasExited)
        //                    process.Kill();
        //            }
        //        }
        //        catch { }
        //    }

    }

}
