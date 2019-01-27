namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System.Collections.Generic;

    /// <summary>
    /// Очередь
    /// </summary>
    /// <author>a.trofimov</author>
    public class Queue : IQueue
    {
        private readonly MQQueue _mqQueue;

        public Queue(MQQueue mqQueue)
        {
            _mqQueue = mqQueue;
        }

        public IEnumerable<MQMessage> GetAllMessages()
        {
            while (_mqQueue.CurrentDepth > 0)
            {
                yield return GetMessage();
            }
        }

        public MQMessage GetMessage()
        {
            var message = new MQMessage();
            _mqQueue.Get(message);
            return message;
        }

        public void PutMessage(MQMessage message, IEnumerable<KeyValuePair<string, string>> stringProperties = null)
        {
            if (stringProperties != null)
            {
                foreach (var prop in stringProperties)
                {
                    message.SetStringProperty(prop.Key, prop.Value);
                }
            }
            _mqQueue.Put(message);
        }

        public int CurrentLength
        {
            get { return _mqQueue.CurrentDepth; }
        }

        public void Close()
        {
            if (_mqQueue != null && _mqQueue.IsOpen)
            {
                _mqQueue.Close();
            }
        }

        public MQMessage BrowseNextMessage(bool resetToFirstMessage = false)
        {
            var opts = new MQGetMessageOptions { Options = resetToFirstMessage ? MQC.MQGMO_BROWSE_FIRST : MQC.MQGMO_BROWSE_NEXT };
            var message = new MQMessage();
            _mqQueue.Get(message, opts);
            return message;
        }

        public void Dispose()
        {
            Close();
        }
    }
}