using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RCCFLib.Records
{
    #region structures

    public enum ValueType
    {
        String = 1,
        Integer,
        Float,
        DateTime
    }

    #endregion

    #region classes

    [DataContract]
    public class RecordingSet
    {
        [DataMember]
        public int RecordingSetId
        {
            get;
            set;
        }

        [DataMember]
        public Guid RecordingRunId
        {
            get;
            set;
        }
        
        [DataMember]
        public DateTime RecordingSetDateTime
        {
            get;
            set;
        }

        [DataMember]
        public List<Recording> Recordings
        {
            get;
            set;
        }
    }

    [DataContract]
    public class Recording
    {
        [DataMember]
        public ValueType Type
        {
            get;
            set;
        }
        
        [DataMember]
        public object Value
        {
            get;
            set;
        }

        [DataMember]
        public string Key
        {
            get;
            set;
        }
    }
    
    #endregion
}
