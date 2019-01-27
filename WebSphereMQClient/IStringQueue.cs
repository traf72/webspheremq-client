namespace WebSphereMQClient
{
    using System.Collections.Generic;

    /// <summary>
    /// Интерфейс для строковой очереди
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IStringQueue : IQueue
    {
        /// <summary>
        /// Считывает все сообщения как строки
        /// </summary>
        IEnumerable<string> GetAllMessagesAsString();

        /// <summary>
        /// Считывает одно сообщение как строку
        /// </summary>
        string GetMessageAsString();

        /// <summary>
        /// Помещает строковое сообщение в очередь
        /// </summary>
        void PutStringMessage(string text, IEnumerable<KeyValuePair<string, string>> stringProperties = null);
    }
}