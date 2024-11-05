
using UnityEngine;

namespace IwacchiLab.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// 文字列がnullまたは空白であるかを判定します。
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 文字列がnullまたは空であるかを判定します。
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        
        /// <summary>
        /// 文字列の先頭と末尾の空白を取り除きます。
        /// </summary>
        public static string TrimWhitespace(this string str)
        {
            return str.Trim();
        }
        
        /// <summary>
        /// 指定した長さで文字列を切り取り、末尾に「...」を追加します。
        /// </summary>
        /// <param name="maxLength">切り取り後の文字列の最大長さ（「...」を含まない長さ）</param>
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || maxLength <= 0)
                return string.Empty;

            return str.Length > maxLength ? str.Substring(0, maxLength) + "..." : str;
        }
        
        /// <summary>
        /// 16進数のカラーコードをColor型に変換します。
        /// 例："#FFFFFF" → Color.white
        /// </summary>
        public static Color ToColorFromHex(this string hex)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }
            else
            {
                Debug.LogWarning("無効なカラーコードです: " + hex);
                return Color.black; // デフォルトとして黒を返す
            }
        }

    }
}
