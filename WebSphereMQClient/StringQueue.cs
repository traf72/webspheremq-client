namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Строковая очередь
    /// </summary>
    /// <author>a.trofimov</author>
    public class StringQueue : Queue, IStringQueue
    {
        public StringQueue(MQQueue mqQueue)
            : base(mqQueue)
        {
        }

        public IEnumerable<string> GetAllMessagesAsString()
        {
            IEnumerable<MQMessage> messages = GetAllMessages();
            return messages.Select(message => message.ReadString(message.MessageLength));
        }

        public string GetMessageAsString()
        {
            var message = GetMessage();
            return message.ReadString(message.MessageLength);
        }

        public void PutStringMessage(string text, IEnumerable<KeyValuePair<string, string>> stringProperties = null)
        {
            var message = new MQMessage { Format = MQC.MQFMT_STRING };
            message.WriteString(text);
            PutMessage(message, stringProperties);
        }
    }
}