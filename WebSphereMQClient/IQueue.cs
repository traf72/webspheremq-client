namespace WebSphereMQClient
{
    using IBM.WMQ;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IQueue : IDisposable
    {
        /// <summary>
        /// ��������� ��� ���������
        /// </summary>
        IEnumerable<MQMessage> GetAllMessages();

        /// <summary>
        /// ��������� ���� ���������
        /// </summary>
        MQMessage GetMessage();

        /// <summary>
        /// �������� ��������� � �������
        /// </summary>
        void PutMessage(MQMessage message, IEnumerable<KeyValuePair<string, string>> stringProperties = null);

        /// <summary>
        /// ���������� ������� ����� �������
        /// </summary>
        int CurrentLength { get; }

        /// <summary>
        /// ��������� �������
        /// </summary>
        void Close();

        /// <summary>
        /// �������� ��������� ���������, �� �� ������� ��� �� �������
        /// </summary>
        MQMessage BrowseNextMessage(bool resetToFirstMessage = false);
    }
}