using System;

namespace IwacchiLab.Utils
{
    public static class ConvertUtility
    {
        /// <summary>
        /// 符号付き整数を符号なし整数に変換します
        /// </summary>
        public static uint IntToUInt(int value)
        {
            return (uint)(value & 0xFFFFFFFF);
        }

        /// <summary>
        /// 符号なし整数を符号付き整数に変換します。
        /// </summary>
        public static int UIntToInt(uint value)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
        }
    }
}