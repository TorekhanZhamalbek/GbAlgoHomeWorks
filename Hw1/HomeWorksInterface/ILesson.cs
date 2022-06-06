using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorksInterface
{
    public interface ILesson
    {
        /// <summary>
        /// Номер ДЗ
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Описание ДЗ
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Запускает ДЗ
        /// </summary>
        void Run();
    }
}
