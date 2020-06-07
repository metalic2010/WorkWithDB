using System.Threading;
using System.Windows.Forms;

namespace ChildJob.Classes
{
    class ChildJobCl
    {
        /// <summary>
        /// Создание и запуск дочернего процесса
        /// </summary>
        /// <param name="ActionThread">Принмиает переменную типа ThreadStart</param>
        public void ThreadProc(ThreadStart ActionThread)
        {            
            Thread StartCaller = new Thread(ActionThread);

            StartCaller.Start();
        }
    }
}
