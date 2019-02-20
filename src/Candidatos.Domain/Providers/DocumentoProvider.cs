using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidatos.Domain.Providers
{

    public abstract class DocumentoProvider<T> : IDocumentoProvider<T> where T : DocumentoBase
    {
        public virtual async Task<IEnumerable<T>> GetDocumentosFromCsvAsync(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            return await ReadFileAsync(path); ;
        }

        private async Task<IEnumerable<T>> ReadFileAsync(string filePath)
        {
            string payload = "";
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath)
                    && File.Exists(filePath)
                    && Path.GetExtension(filePath).Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] linesData = await File.ReadAllLinesAsync(filePath, Encoding.GetEncoding("iso-8859-1"));

                    var lines = linesData.Select(s => s.Replace("\"", string.Empty))
                                         .ToArray();

                    if (lines != null && lines.Length > 1)
                    {
                        var headers = GetHeaders(lines.First());
                        payload = GetPayload(headers, lines.Skip(1));
                    }
                }
            }
            catch (Exception exp)
            {
            }
            return JsonConvert.DeserializeObject<IEnumerable<T>>(payload);
        }

        private IEnumerable<string> GetHeaders(string data)
        {
            IEnumerable<string> headers = null;

            if (!string.IsNullOrWhiteSpace(data) && data.Contains(';'))
            {
                headers = GetFields(data).Select(x => x.Replace(" ", ""));
            }
            return headers;
        }

        private string GetPayload(IEnumerable<string> headers, IEnumerable<string> fields)
        {
            string jsonObject = "";
            try
            {
                var dictionaryList = fields.Select(x => GetField(headers, x));
                jsonObject = JsonConvert.SerializeObject(dictionaryList);
            }
            catch (Exception ex)
            {
            }
            return jsonObject;
        }

        private Dictionary<string, string> GetField(IEnumerable<string> headers, string fields)
        {
            Dictionary<string, string> dictionary = null;

            if (!string.IsNullOrWhiteSpace(fields))
            {
                var columns = GetFields(fields);

                if (columns != null && headers != null && columns.Count() == headers.Count())
                {
                    dictionary = headers.Zip(columns, (x, y) => new { x, y })
                        .ToDictionary(item => item.x, item => item.y);
                }
            }
            return dictionary;
        }

        public IEnumerable<string> GetFields(string line)
        {
            return line.Split(";").ToList();
        }
    }
}
