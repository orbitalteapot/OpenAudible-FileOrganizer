namespace HelpersCore;

public static class Helpers
{
    public static string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var invalidCharsRemoved = new string(fileName
            .Where(ch => !invalidChars.Contains(ch))
            .ToArray());
        invalidCharsRemoved = invalidCharsRemoved.TrimEnd('.', ' ');
        return invalidCharsRemoved;
    }

    public static bool AreFilesSame(string filePath1, string filePath2)
    {
        var fileInfo1 = new FileInfo(filePath1);
        var fileInfo2 = new FileInfo(filePath2);
        if (fileInfo1.Length != fileInfo2.Length)
        {
            return false;
        }

        return true;
    }
}