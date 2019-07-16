using System;
using System.Text;

namespace SimulatorDUKPT
{
    using DukptNet;

    using SimulatorDUKPT.library;

    public class Program
    {
        static void Main(string[] args)
        {
            string bdk = "0123456789ABCDEFFEDCBA9876543210";
            string ksn = "FFFF9876543210E00008";

            string XOR_PIN_PAN = string.Empty;
            string PIN = "123456";
            string PAN = "4766840000704997";
            string key = "AAAABBBBCCCCDDDDEEEEFFFFAAAABBBB";

            libPINBlock.XOR_FORMAT_01(PIN, PAN, out XOR_PIN_PAN);

            XOR_PIN_PAN = XOR_PIN_PAN.Replace(":", string.Empty);

            string clearPinBlock = libPINBlock.getPINBlock(XOR_PIN_PAN, key);

            byte[] encBytes = Dukpt.Encrypt(bdk, ksn, Encoding.UTF8.GetBytes(clearPinBlock));
            string hexaStrPinBlock = BitConverter.ToString(encBytes).Replace("-", string.Empty);

            Console.WriteLine("pinBlock " + clearPinBlock);
            Console.WriteLine("encPinBlock " + hexaStrPinBlock);
            Console.ReadKey();
        }
    }
}
