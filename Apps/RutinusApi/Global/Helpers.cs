using System.Data;
using System.Reflection;

namespace RutinusApi.Global
{
    /// <summary>
    /// Helpers : 전역 헬퍼
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// List : 특정 데이터테이블을 특정 형태의 List 로 변환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
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
