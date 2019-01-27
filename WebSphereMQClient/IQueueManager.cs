namespace WebSphereMQClient
{
    using System;

    /// <summary>
    /// »нтерфейс менеджера очередей
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IQueueManager : IDisposable
    {
        /// <summary>
        /// ѕараметры соединени¤
        /// </summary>
        QueueManagerConnection Connection { get; set; }
        
        /// <summary>
        /// ”станавливает соединение с менеджером очередей
        /// </summary>
        void Connect();

        /// <summary>
        /// ќткрывает очередь
        /// </summary>
        /// <typeparam name="T">“ип очереди</typeparam>
        /// <param name="queueName">»м¤ очереди</param>
        /// <param name="openOptions">ѕараметры очереди</param>
        /// <returns>ќткрыта¤ очередь</returns>
        T OpenQueue<T>(string queueName, int openOptions) where T : IQueue;

        /// <summary>
        /// ќткрывает очередь на чтение
        /// </summary>
        /// <typeparam name="T">“ип очереди</typeparam>
        /// <param name="queueName">»м¤ очереди</param>
        /// <returns>ќткрыта¤ очередь</returns>
        T OpenQueueForGet<T>(string queueName) where T : IQueue;

        /// <summary>
        /// ќткрывает очередь на запись
        /// </summary>
        /// <typeparam name="T">“ип очереди</typeparam>
        /// <param name="queueName">»м¤ очереди</param>
        /// <returns>ќткрыта¤ очередь</returns>
        T OpenQueueForPut<T>(string queueName) where T : IQueue;

        /// <summary>
        /// ќтключаетс¤ от менеджера очередей
        /// </summary>
        void Disconnect();
    }
}