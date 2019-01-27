namespace WebSphereMQClient
{
    using System.Collections.Generic;

    /// <summary>
    /// Интерфейс для байтовой очереди
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IByteQueue : IQueue
    {
        /// <summary>
        /// Считывает все сообщения как строки
        /// </summary>
        IEnumerable<byte[]> GetAllMessagesAsByteArray();

        /// <summary>
        /// Считывает одно сообщение как массив байт
        /// </summary>
        byte[] GetMessageAsByteArray();

        /// <summary>
        /// Помещает строковое сообщение в очередь
        /// </summary>
        void PutByteArrayMessage(string text, IEnumerable<KeyValuePair<string, string>> stringProperties = null);
    }
}