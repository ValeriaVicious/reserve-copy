using System.IO;


namespace GeekBrains
{
    public sealed class StreamData : IData<SavedData>
    {
        public SavedData Load(string path = null)
        {
            var result = new SavedData();

            using (var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    result.Name = streamReader.ReadLine();
                    result.Position.X = streamReader.ReadLine().TrySingle();
                    result.Position.Y = streamReader.ReadLine().TrySingle();
                    result.Position.Z = streamReader.ReadLine().TrySingle();
                    result.IsEnabled = streamReader.ReadLine().TryBool():
                }
            }
            return result;
        }

        public void Save(SavedData data, string path = null)
        {
            if (path == null)
            {
                return;
            }

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data.Name);
                streamWriter.WriteLine(data.Position.X);
                streamWriter.WriteLine(data.Position.Y);
                streamWriter.WriteLine(data.Position.Z);
                streamWriter.WriteLine(data.IsEnabled);
            }
        }
    }
}
