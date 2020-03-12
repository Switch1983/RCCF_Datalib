using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RCCFLib.Records;

namespace RCCFLib
{
    public class DataAccess
    {
        public static List<RCCFLib.Records.RecordingSet> GetRecordingSetSeries(int recordingSetId)
        {
            LinqObjectsDataContext dataContext = new LinqObjectsDataContext();
            var recordingSets = dataContext.RecordingSets.Where(p => p.RecordingSetId == recordingSetId);
            
            List<RCCFLib.Records.RecordingSet> allRecordingSets = new List<RCCFLib.Records.RecordingSet>();

            foreach (RecordingSet thisRecordingSet in recordingSets)
            {
                RCCFLib.Records.RecordingSet newRecordingSet = new RCCFLib.Records.RecordingSet();
                newRecordingSet.RecordingSetDateTime = thisRecordingSet.RecordingSetDateTime;
                newRecordingSet.RecordingSetId       = thisRecordingSet.RecordingSetId;

                var recordings = dataContext.Recordings.Where(p => p.RecordingSetId == recordingSetId);

                newRecordingSet.Recordings = new List<RCCFLib.Records.Recording>();
                foreach (Recording thisRecording in recordings)
                {
                    RCCFLib.Records.Recording newRecording = new RCCFLib.Records.Recording();
                  
                    newRecording.Type = (Records.ValueType)thisRecording.Type;

                    switch ((Records.ValueType)thisRecording.Type)
                    {
                        case Records.ValueType.DateTime:
                            newRecording.Value = thisRecording.DateTimeValue;
                            break;
                        case Records.ValueType.Float:
                            newRecording.Value = thisRecording.FloatValue;
                            break;
                        case Records.ValueType.Integer:
                            newRecording.Value = thisRecording.IntValue;
                            break;
                        case Records.ValueType.String:
                            newRecording.Value = thisRecording.StringValue;
                            break;
                        default:
                            break;
                    }

                    newRecordingSet.Recordings.Add(newRecording);
                }
            }

            return allRecordingSets;
        }

        public static List<RCCFLib.Records.RecordingSet> GetRecordingSetSeriesFrom(int recordingSetId, DateTime fromDateTime)
        {
            LinqObjectsDataContext dataContext = new LinqObjectsDataContext();
            var recordingSets = dataContext.RecordingSets.Where(p => p.RecordingSetId == recordingSetId);

            List<RCCFLib.Records.RecordingSet> allRecordingSets = new List<RCCFLib.Records.RecordingSet>();

            foreach (RecordingSet thisRecordingSet in recordingSets)
            {
                RCCFLib.Records.RecordingSet newRecordingSet = new RCCFLib.Records.RecordingSet();
                newRecordingSet.RecordingSetDateTime = thisRecordingSet.RecordingSetDateTime;
                newRecordingSet.RecordingSetId = thisRecordingSet.RecordingSetId;

                var recordings = dataContext.Recordings.Where(p => p.RecordingSetId == recordingSetId);

                newRecordingSet.Recordings = new List<RCCFLib.Records.Recording>();
                foreach (Recording thisRecording in recordings)
                {
                    RCCFLib.Records.Recording newRecording = new RCCFLib.Records.Recording();

                    newRecording.Type = (Records.ValueType)thisRecording.Type;

                    switch ((Records.ValueType)thisRecording.Type)
                    {
                        case Records.ValueType.DateTime:
                            newRecording.Value = thisRecording.DateTimeValue;
                            break;
                        case Records.ValueType.Float:
                            newRecording.Value = thisRecording.FloatValue;
                            break;
                        case Records.ValueType.Integer:
                            newRecording.Value = thisRecording.IntValue;
                            break;
                        case Records.ValueType.String:
                            newRecording.Value = thisRecording.StringValue;
                            break;
                        default:
                            break;
                    }

                    newRecordingSet.Recordings.Add(newRecording);
                }
            }

            return allRecordingSets;
        }

        public static List<RCCFLib.Records.RecordingSet> GetRecordingSetSeriesFromTo(int recordingSetId, DateTime fromDateTime, DateTime toDateTime)
        {
            LinqObjectsDataContext dataContext = new LinqObjectsDataContext();
            var recordingSets = dataContext.RecordingSets.Where(p => p.RecordingSetId == recordingSetId && p.RecordingSetDateTime >= fromDateTime && p.RecordingSetDateTime <= toDateTime);

            List<RCCFLib.Records.RecordingSet> allRecordingSets = new List<RCCFLib.Records.RecordingSet>();

            foreach (RecordingSet thisRecordingSet in recordingSets)
            {
                RCCFLib.Records.RecordingSet newRecordingSet = new RCCFLib.Records.RecordingSet();
                newRecordingSet.RecordingSetDateTime = thisRecordingSet.RecordingSetDateTime;
                newRecordingSet.RecordingSetId = thisRecordingSet.RecordingSetId;

                var recordings = dataContext.Recordings.Where(p => p.RecordingSetId == recordingSetId);

                newRecordingSet.Recordings = new List<RCCFLib.Records.Recording>();
                foreach (Recording thisRecording in recordings)
                {
                    RCCFLib.Records.Recording newRecording = new RCCFLib.Records.Recording();

                    newRecording.Type = (Records.ValueType)thisRecording.Type;

                    switch ((Records.ValueType)thisRecording.Type)
                    {
                        case Records.ValueType.DateTime:
                            newRecording.Value = thisRecording.DateTimeValue;
                            break;
                        case Records.ValueType.Float:
                            newRecording.Value = thisRecording.FloatValue;
                            break;
                        case Records.ValueType.Integer:
                            newRecording.Value = thisRecording.IntValue;
                            break;
                        case Records.ValueType.String:
                            newRecording.Value = thisRecording.StringValue;
                            break;
                        default:
                            break;
                    }

                    newRecordingSet.Recordings.Add(newRecording);
                }
            }

            return allRecordingSets;
        }

        public static RCCFLib.Records.RecordingSet GetLatestReading(int recordingSetId)
        {
            LinqObjectsDataContext dataContext = new LinqObjectsDataContext();
            var recordingSet = dataContext.RecordingSets.FirstOrDefault(p => p.RecordingSetId == recordingSetId);

            RCCFLib.Records.RecordingSet newRecordingSet = new RCCFLib.Records.RecordingSet();

            newRecordingSet.RecordingSetDateTime = recordingSet.RecordingSetDateTime;
            newRecordingSet.RecordingSetId = recordingSet.RecordingSetId;

            var recordings = dataContext.Recordings.Where(p => p.RecordingSetId == recordingSetId);

            newRecordingSet.Recordings = new List<RCCFLib.Records.Recording>();
            foreach (Recording thisRecording in recordings)
            {
                RCCFLib.Records.Recording newRecording = new RCCFLib.Records.Recording();

                newRecording.Type = (Records.ValueType)thisRecording.Type;

                switch ((Records.ValueType)thisRecording.Type)
                {
                    case Records.ValueType.DateTime:
                        newRecording.Value = thisRecording.DateTimeValue;
                        break;
                    case Records.ValueType.Float:
                        newRecording.Value = thisRecording.FloatValue;
                        break;
                    case Records.ValueType.Integer:
                        newRecording.Value = thisRecording.IntValue;
                        break;
                    case Records.ValueType.String:
                        newRecording.Value = thisRecording.StringValue;
                        break;
                    default:
                        break;
                }

                newRecordingSet.Recordings.Add(newRecording);
            }

            return newRecordingSet;
        }


        public static void AddRecordingSet(RCCFLib.Records.RecordingSet recordingSet)
        {
            LinqObjectsDataContext dataContext = new LinqObjectsDataContext();

            RecordingSet newRecordingSet = new RecordingSet();
            newRecordingSet.RecordingSetDateTime = recordingSet.RecordingSetDateTime;
            newRecordingSet.RecordingSetId = recordingSet.RecordingSetId;
            newRecordingSet.RecordingRunId = recordingSet.RecordingRunId;

            dataContext.RecordingSets.InsertOnSubmit(newRecordingSet);

            foreach (Records.Recording thisRecording in recordingSet.Recordings)
            {
                Recording newRecording = new Recording();
                newRecording.Key = thisRecording.Key;
                newRecording.RecordingSetId = recordingSet.RecordingSetId;
                switch (thisRecording.Type)
                {
                    case Records.ValueType.DateTime:
                        newRecording.DateTimeValue = DateTime.Parse(thisRecording.Value.ToString());
                        break;
                    case Records.ValueType.Float:
                        newRecording.FloatValue = float.Parse(thisRecording.Value.ToString());
                        break;
                    case Records.ValueType.Integer:
                        newRecording.IntValue = Int32.Parse(thisRecording.Value.ToString());
                        break;
                    case Records.ValueType.String:
                        newRecording.StringValue = thisRecording.Value.ToString();
                        break;
                    default:
                        break;
                }

                dataContext.Recordings.InsertOnSubmit(newRecording);
            }

            dataContext.SubmitChanges();
        }
    }
}
