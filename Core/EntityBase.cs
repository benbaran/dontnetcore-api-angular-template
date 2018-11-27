using Newtonsoft.Json;
using System;

namespace Core
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
