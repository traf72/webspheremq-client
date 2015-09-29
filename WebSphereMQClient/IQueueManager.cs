namespace WebSphereMQClient
{
    using System;

    /// <summary>
    /// ��������� ��������� ��������
    /// </summary>
    /// <author>a.trofimov</author>
    public interface IQueueManager : IDisposable
    {
        /// <summary>
        /// ��������� ����������
        /// </summary>
        QueueManagerConnection Connection { get; set; }
        
        /// <summary>
        /// ������������� ���������� � ���������� ��������
        /// </summary>
        void Connect();

        /// <summary>
        /// ��������� �������
        /// </summary>
        /// <typeparam name="T">��� �������</typeparam>
        /// <param name="queueName">��� �������</param>
        /// <param name="openOptions">��������� �������</param>
        /// <returns>�������� �������</returns>
        T OpenQueue<T>(string queueName, int openOptions) where T : IQueue;

        /// <summary>
        /// ��������� ������� �� ������
        /// </summary>
        /// <typeparam name="T">��� �������</typeparam>
        /// <param name="queueName">��� �������</param>
        /// <returns>�������� �������</returns>
        T OpenQueueForGet<T>(string queueName) where T : IQueue;

        /// <summary>
        /// ��������� ������� �� ������
        /// </summary>
        /// <typeparam name="T">��� �������</typeparam>
        /// <param name="queueName">��� �������</param>
        /// <returns>�������� �������</returns>
        T OpenQueueForPut<T>(string queueName) where T : IQueue;

        /// <summary>
        /// ����������� �� ��������� ��������
        /// </summary>
        void Disconnect();
    }
}