using System;
using System.Collections.Generic;

namespace HealthInformationProgram.Data.Tables
{
    public partial class tmp_JsonVisit
    {
        public int element_id { get; set; }
        public Nullable<int> sequenceNo { get; set; }
        public Nullable<int> parent_ID { get; set; }
        public Nullable<int> Object_ID { get; set; }
        public string Name { get; set; }
        public string StringValue { get; set; }
        public string ValueType { get; set; }
        public string visit_uuid { get; set; }
    }
}
