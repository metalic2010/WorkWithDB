using System;
using System.IO;
using System.Text;
using System.Security.Principal;
using IL = ILogs.Interfaces;
using System.Windows.Forms;

namespace LogHelper.Classes
{
    public class Log : IL.ILogs
    {
        /// <summary>
        /// Переменная для блокровки в случае одновременной записи
        /// </summary>
        private static object sync = new object();

        /// <summary>
        /// Переменная идентифицирующая пользователя
        /// Это необходимо для ведения раздельных логов
        /// </summary>
        private static string userName = WindowsIdentity.GetCurrent().Name;

        /// <summary>
        /// Записывает в лог файл переданые файлы
        /// Директория определяется от места расположения exe файла
        /// и добавляется директория log
        /// </summary>
        /// <param name="TextMessage">Текст сообщения</param>
        public void Write(String TextMessage)
        {
            try
            {
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно

                string filename = Path.Combine(pathToLog,
                    string.Format("{0}_{1:dd.MM.yyy}_{2}.log",
                    "Test", DateTime.Now, userName.Replace("\\", "_")));

                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss}] - {1}\r\n", DateTime.Now, TextMessage);

                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка записи лог файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}