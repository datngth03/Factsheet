using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Sabeco_Factsheet.Blazor.Client.Pages
{
    public static class FileHelper
    {
        // Loại bỏ ký tự không hợp lệ trong tên file
        public static string SanitizeFileName(string fileName)
        {
            // Loại bỏ ký tự không hợp lệ
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitizedFileName = new string(fileName
                .Where(ch => !invalidChars.Contains(ch))
                .ToArray());

            // Thay thế ký tự đặc biệt bằng dấu gạch dưới
            sanitizedFileName = Regex.Replace(sanitizedFileName, @"[^a-zA-Z0-9]", "_", RegexOptions.Compiled);

            return sanitizedFileName;
        }


        // Loại bỏ dấu trong nội dung
        private static readonly string[] VietnameseSigns = new string[]
        {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
        }; 
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                {
                    text = text.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
                }
            }
            return text;
        }


        // Kiểm tra dữ liệu cũ - mới khác hay giống
        public static bool ArePropertiesEqual<T>(T obj1, T obj2)
        {
            if (obj1 == null || obj2 == null)
                return obj1 == null && obj2 == null; // Nếu cả hai đều null thì coi là bằng nhau

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);

                // Xử lý trường hợp giá trị là chuỗi rỗng và null
                if (value1 is string s1 && s1 == "" && value2 == null)
                    value2 = null;
                if (value1 == null && value2 is string s2 && s2 == "")
                    value1 = null;

                if (!object.Equals(value1, value2))
                    return false;
            }
            return true;
        }


        // Kiểm tra dữ liệu cũ - mới khác hay giống 
        public static Dictionary<string, string> GetAllFieldValues<TDto>(TDto item)
        {
            var values = new Dictionary<string, string>();
            var properties = typeof(TDto).GetProperties();

            // Lấy giá trị tất cả các thuộc tính của đối tượng, loại bỏ các trường không cần thiết
            foreach (var property in properties)
            {
                // Loại bỏ các trường không cần thiết
                if (property.Name == "LastModificationTime" || property.Name == "LastModifierId" ||
                    property.Name == "CreationTime" || property.Name == "CreatorId" ||
                    property.Name == "IsChanged" || property.Name == "Idx")
                {
                    continue;
                }

                var value = property.GetValue(item)?.ToString() ?? "null";
                values.Add(property.Name, value);
            }

            return values;
        }
    }
}
