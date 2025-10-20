using System.Data;
using System.Reflection;

namespace RutinusApi.Global
{
    public static class Helpers
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (DataRow row in table.Rows)
            {
                var item = new T();
                foreach (var prop in properties)
                {
                    if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(item, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                    }
                }
                list.Add(item);
            }

            return list;
        }
    }
}
