namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Байтовая очередь
    /// </summary>
    /// <author>a.trofimov</author>
    public class ByteQueue : Queue, IByteQueue
    {
        public ByteQueue(MQQueue mqQueue)
            : base(mqQueue)
        {
        }

        public IEnumerable<byte[]> GetAllMessagesAsByteArray()
        {
            IEnumerable<MQMessage> messages = GetAllMessages();
            return messages.Select(message => message.ReadBytes(message.MessageLength));
        }

        public byte[] GetMessageAsByteArray()
        {
            var message = GetMessage();
            return message.ReadBytes(message.MessageLength);
        }

        public void PutByteArrayMessage(string text, IEnumerable<KeyValuePair<string, string>> stringProperties = null)
        {
            var message = new MQMessage();
            message.WriteBytes(text);
            PutMessage(message, stringProperties);
        }
    }
}