namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System;
    using System.Collections;

    /// <summary>
    /// Менеджер очередей
    /// </summary>
    /// <author>a.trofimov</author>
    public class QueueManager : IQueueManager
    {
        private MQQueueManager _mqQueueManager;

        public QueueManager(QueueManagerConnection connection)
        {
            Connection = connection;
        }

        public void Connect()
        {
            _mqQueueManager = new MQQueueManager(Connection.QueueManagerName, GetConnectionProperties());
        }

        public QueueManagerConnection Connection { get; set; }

        private Hashtable GetConnectionProperties()
        {
            var connectionProperties = new Hashtable
            {
                { MQC.TRANSPORT_PROPERTY, Connection.ConnectionType },
                { MQC.CCSID_PROPERTY, Connection.Ccsid }
            };
            switch (Connection.ConnectionType)
            {
                case MQC.TRANSPORT_MQSERIES_BINDINGS:
                    break;

                case MQC.TRANSPORT_MQSERIES_CLIENT:
                case MQC.TRANSPORT_MQSERIES_XACLIENT:
                case MQC.TRANSPORT_MQSERIES_MANAGED:
                    connectionProperties.Add(MQC.HOST_NAME_PROPERTY, Connection.HostName);
                    connectionProperties.Add(MQC.PORT_PROPERTY, Connection.Port);
                    connectionProperties.Add(MQC.CHANNEL_PROPERTY, Connection.Channel);
                    if (!string.IsNullOrWhiteSpace(Connection.UserName))
                    {
                        connectionProperties[MQC.USER_ID_PROPERTY] = Connection.UserName;
                        connectionProperties[MQC.PASSWORD_PROPERTY] = Connection.UserPassword;
                    }
                    break;
            }
            return connectionProperties;
        }

        public T OpenQueue<T>(string queueName, int openOptions) where T : IQueue
        {
            return (T)Activator.CreateInstance(typeof(T), _mqQueueManager.AccessQueue(queueName, openOptions));
        }

        public T OpenQueueForGet<T>(string queueName) where T : IQueue
        {
            return OpenQueue<T>(queueName, MQC.MQOO_INPUT_AS_Q_DEF | MQC.MQOO_INQUIRE);
        }

        public T OpenQueueForPut<T>(string queueName) where T : IQueue
        {
            return OpenQueue<T>(queueName, MQC.MQOO_OUTPUT | MQC.MQOO_INQUIRE);
        }

        public void Disconnect()
        {
            if (_mqQueueManager != null && _mqQueueManager.IsConnected)
            {
                _mqQueueManager.Disconnect();
            }
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}