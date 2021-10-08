using System.Collections.Generic;

namespace QueCapricho.Domain.ValueObjects
{
    public class Result
    {
        public Result()
        {
            Messages = new List<string>();
        }

        public object Return { get; set; }
        public List<string> Messages { get; set; }
    }
}
