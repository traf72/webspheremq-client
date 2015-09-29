namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System.ComponentModel;

    /// <summary>
    /// Коннекшн для менеджера очередей
    /// </summary>
    /// <author>a.trofimov</author>
    public class QueueManagerConnection
    {
        public QueueManagerConnection()
        {
            Port = 1414;
            ConnectionType = MQC.TRANSPORT_MQSERIES_MANAGED;
            Ccsid = 1208; // http://www-01.ibm.com/software/globalization/ccsid/ccsid1208.html
        }

        /// <summary>
        /// Имя менеджера очередей
        /// </summary>
        public string QueueManagerName { get; set; }

        /// <summary>
        /// Имя или IP хоста
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Номер порта
        /// </summary>
        [DefaultValue(1414)]
        public int Port { get; set; }

        /// <summary>
        /// Имя канала
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Тип соединения
        /// </summary>
        [DefaultValue(MQC.TRANSPORT_MQSERIES_MANAGED)]
        public string ConnectionType { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// Coded Character Set ID
        /// </summary>
        [DefaultValue(1208)]
        public int Ccsid { get; set; }
    }
}