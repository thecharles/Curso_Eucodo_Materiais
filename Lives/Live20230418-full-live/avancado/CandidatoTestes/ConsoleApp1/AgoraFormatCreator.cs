using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters
{
    /// <summary>
    /// Responsible to handle the way we are going to format the log in "agora format".
    /// </summary>
    public class AgoraFormatCreator
    {
        List<string> fields = new List<string>();

        public void AddField(string? fieldContent)
        {
            if(fieldContent != null)
                fields.Add(fieldContent);
        }

        public void AddField(decimal valor)
        {
            fields.Add(valor.ToString().Replace(".", "").Replace(",", ".")); // comma will be "." and no thousands separator.
        }

        public void AddFields(List<string> fields)
        {
            fields.AddRange(fields);
        }

        public string GetFieldsFormatted()
        {
            return string.Join(" ", fields.ToArray());
        }
    }
}
