using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfProject
{
    
      [ServiceContract]
    public interface IService1
    {
        // Interfacete gozuken metodlar web service olarak kullanılabilir
        [OperationContract]
        List<Record> GetRecord(string recordName);
        [OperationContract]
        Record GetRecordById(int id);


        [OperationContract]
        string InsertRecord(Record record);

        [OperationContract]
        List<Record> GetAllRecord();

        [OperationContract]
        bool UpdateRecord(Record record);

        [OperationContract]
        bool DeleteRecord(int recordId);
        //First or default mantigiyla yazdim
        [OperationContract]
        bool DeleteRecordByName(string recordInfo);
        [OperationContract]
        bool FindById(int recordId);

    }

    [DataContract]
    public class Record
    {
        int id;
        string name = string.Empty;
        string surname = string.Empty;
        int age;
        

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    
}
