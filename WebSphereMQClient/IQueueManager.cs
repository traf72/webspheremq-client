namespace WebSphereMQClient
{
    using System;

    /// <summary>
    /// Интерфейс менеджера очередей
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IQueueManager : IDisposable
    {
        /// <summary>
        /// Параметры соединения
        /// </summary>
        QueueManagerConnection Connection { get; set; }
        
        /// <summary>
        /// Устанавливает соединение с менеджером очередей
        /// </summary>
        void Connect();

        /// <summary>
        /// Открывает очередь
        /// </summary>
        /// <typeparam name="T">Тип очереди</typeparam>
        /// <param name="queueName">Имя очереди</param>
        /// <param name="openOptions">Параметры очереди</param>
        /// <returns>Открытая очередь</returns>
        T OpenQueue<T>(string queueName, int openOptions) where T : IQueue;

        /// <summary>
        /// Открывает очередь на чтение
        /// </summary>
        /// <typeparam name="T">Тип очереди</typeparam>
        /// <param name="queueName">Имя очереди</param>
        /// <returns>Открытая очередь</returns>
        T OpenQueueForGet<T>(string queueName) where T : IQueue;

        /// <summary>
        /// Открывает очередь на запись
        /// </summary>
        /// <typeparam name="T">Тип очереди</typeparam>
        /// <param name="queueName">Имя очереди</param>
        /// <returns>Открытая очередь</returns>
        T OpenQueueForPut<T>(string queueName) where T : IQueue;

        /// <summary>
        /// Отключается от менеджера очередей
        /// </summary>
        void Disconnect();
    }
}