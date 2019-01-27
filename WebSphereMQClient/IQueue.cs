namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Интерфейс очереди
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IQueue : IDisposable
    {
        /// <summary>
        /// Считывает все сообщения
        /// </summary>
        IEnumerable<MQMessage> GetAllMessages();

        /// <summary>
        /// Считывает одно сообщение
        /// </summary>
        MQMessage GetMessage();

        /// <summary>
        /// Помещает сообщение в очередь
        /// </summary>
        void PutMessage(MQMessage message, IEnumerable<KeyValuePair<string, string>> stringProperties = null);

        /// <summary>
        /// Возвращает текушую длину очереди
        /// </summary>
        int CurrentLength { get; }

        /// <summary>
        /// Закрывает очередь
        /// </summary>
        void Close();

        /// <summary>
        /// Получает следующее сообщение, но не удаляет его из очереди
        /// </summary>
        MQMessage BrowseNextMessage(bool resetToFirstMessage = false);
    }
}