using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IExportDBF.Interfaces
{
    /// <summary>
    /// Основной интерфейс, описаны только основные действия
    /// </summary>
    interface IExportDBF
    {
        /// <summary>
        /// Запись в dbf файл
        /// </summary>
        /// <param name="SQLQuery">Строка - команда sql</param>
        void SetDBF(string SQLQuery);

        /// <summary>
        /// Чтение из DBF файла
        /// </summary>
        /// <param name="SQLQuery">Строка - команда sql</param>
        /// <returns>Возврщает DataTable</returns>
        DataTable GetDBF(string SQLQuery);

        /// <summary>
        /// Создаёт DBF таблицу
        /// </summary>
        /// <param name="name">Имя будущей таблицы</param>
        /// <param name="Fields">Наименования столбцов и их тип</param>
        /// <returns>Возвращает DataTable</returns>
        void CreateDBF(string name, string[] Fields);
    }

    /// <summary>
    /// Добавочный интерфейс, описаны действия с dataGridView
    /// </summary>
    interface IExportDBFDataGrid
    {
        /// <summary>
        /// Получение информации о именах столбцов и их типах
        /// </summary>
        /// <param name="dataGridView">Получаем объект таблицы</param>
        /// <returns>Возвращает список</returns>
        List<string[]> GetFieldInfo(DataGridView dataGridView);

        /// <summary>
        /// Собирает значения и производит их слияние
        /// </summary>
        /// <param name="dataGridView">Получаем объект таблицы</param>
        /// <returns>Возвращает список</returns>
        string[] GetValuesConcat(DataGridView dataGridView);
    }
}
