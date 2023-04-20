using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Convert.Converters.AgoraFormat
{
    /// <summary>
    /// Responsible to handle the way we are going to format the log in "agora format".
    /// </summary>
    public class AgoraFormatCreator
    {
        List<string> fields = new List<string>();

        public void AddField(string? fieldContent)
        {
            if (fieldContent != null)
                fields.Add(fieldContent);
        }

        public void AddField(decimal valor)
        {
            AddField(valor.ToString("N0").Replace(".", "")); // no decimals and no thousands separator (i guessed this from the pdf especification)
        }

        public void AddFields(List<string> _fields)
        {
            fields.AddRange(_fields);
        }

        public string GetFieldsFormatted()
        {
            return string.Join(" ", fields.ToArray());
        }
    }
}
