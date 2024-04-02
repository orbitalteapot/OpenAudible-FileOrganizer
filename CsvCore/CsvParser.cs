using System.Globalization;
using CsvHelper;
using ModelsCore.Mapping;
using ModelsCore.Models;

namespace CsvCore;

public class CsvParser
{
    public async Task<List<OpenAudibleBookModel>> ParseDataCsv(string fullPath, CancellationToken token)
    {
        using var reader = new StreamReader(fullPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        try
        {
            csv.Context.RegisterClassMap<AudiobookMap>();
            return await csv.GetRecordsAsync<OpenAudibleBookModel>(token).ToListAsync(token);
        }
        finally
        {
            reader.Close();
        }
    }
}