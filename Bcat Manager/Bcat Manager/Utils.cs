using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bcat_Manager
{
    public class Utils
    {

        public static Bitmap GetBitmap(byte[] buffer)
        {
            //assuming buffer is in JPG format
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                return (Bitmap)Image.FromStream(ms);
            }
        }


        public static bool IsValidDeviceID(string id)
        {
            return Regex.IsMatch(id, "^(XA(J|W)[0-9]{11})$");
        }

        public static bool IsValidSdkVersion(string version)
        {

            string[] splitted = version.Split('.');

            if (splitted.Length != 4)
                return false;

            foreach (var s in splitted)
                if (!byte.TryParse(s, out byte res))
                    return false;

            return true;
        }
        //pass
        public static bool IsValidPassphrase(string pass)
        {
            return Regex.IsMatch(pass, "^[0-9a-fA-F]{64}$");
        }

        //title id
        public static string GetBaseTitle(long tid)
        {
            return GetBaseTitle(tid.ToString("X16"));
        }
        public static string GetBaseTitle(string tid)
        {
            return tid.Remove(13) + "000";
        }
        public static bool IsValidTid(string tid)
        {
            return Regex.IsMatch(tid, "^0100[0-9a-fA-F]{12}$");
        }
        public static bool IsValidTid(long tid)
        {
            return IsValidTid(tid.ToString("X16"));
        }

        //convertsion
        public static byte[] HexToBytes(string hex)
        {
            hex = hex.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }
        public static string BytesToHex(byte[] bytes, string separator)
        {
            return BitConverter.ToString(bytes).Replace("-", separator);
        }
    }
}
