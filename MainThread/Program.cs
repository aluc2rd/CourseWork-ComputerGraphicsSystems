using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Std
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Включение визуальных стилей для приложения
            Application.EnableVisualStyles();
            // Установка совместимости отображения текста по умолчанию
            Application.SetCompatibleTextRenderingDefault(false);
            // Запуск главного окна приложения
            Application.Run(new Form1());
        }
    }
}
