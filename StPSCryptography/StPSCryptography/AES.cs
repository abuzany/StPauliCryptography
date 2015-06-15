using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StPauliSystems.Security.Cryptography.File
{
    public class AES
    {
        [DllImport("AesFile2.dll", EntryPoint = "getHexKey")]
        private static extern int getHexKey(string key_in_ascci, string key_out_hex);

        [DllImport("AesFile2.dll", EntryPoint = "?aesFileCrypt@@YGHDPAD00@Z")]
        private static extern int aesFileCrypt(char bEncrypt, string in_filename, string out_filename, string key_in_hex);

        public static void Encrypt(string inFIle, string outFile)
        {
            try
            {
                StringBuilder hexKey = new StringBuilder(255);
                string msg;
                string auxMsg;

                int res;

                hexKey.Append((char)52);
                hexKey.Append((char)101);
                hexKey.Append((char)55);
                hexKey.Append((char)53);
                hexKey.Append((char)55);
                hexKey.Append((char)56);
                hexKey.Append((char)54);
                hexKey.Append((char)57);
                hexKey.Append("6261456e63727970746f7232");

                Console.WriteLine("Encrypt file from: {0}, to: {1}", inFIle, outFile);

                res = aesFileCrypt((char)1, inFIle, outFile, hexKey.ToString());

                if (res != 0)
                {
                    switch (res)
                    {

                        case 0: msg = "OK";
                            break;
                        case -2: msg = "Key must be in hexadecimal notation";
                            break;
                        case -3: msg = "key too long";
                            break;
                        case -4: msg = "The key length must be 32, 48 or 64 hexadecimal digits";
                            break;
                        case -5: msg = "The input file could not be opened";
                            break;
                        case -6: msg = "The output file could not be opened";
                            break;
                        case -7: msg = "Error reading from input file";
                            break;
                        case -8: msg = "Error reading from output file";
                            break;
                        default:
                            msg = string.Format("Unknown:{0}", res);
                            break;

                    }

                    auxMsg = string.Format("Error to Decrytp file: csSource {0}->{1}", inFIle, msg);

                    throw new Win32Exception(res, auxMsg);
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Decrypt(string inFIle, string outFile)
        {
            try
            {
                StringBuilder hexKey = new StringBuilder(255);
                string msg;
                string auxMsg;

                int res;

                hexKey.Append((char)52);
                hexKey.Append((char)101);
                hexKey.Append((char)55);
                hexKey.Append((char)53);
                hexKey.Append((char)55);
                hexKey.Append((char)56);
                hexKey.Append((char)54);
                hexKey.Append((char)57);
                hexKey.Append("6261456e63727970746f7232");

                Console.WriteLine("Decrypting file from: {0}, to: {1}", inFIle, outFile);

                res = aesFileCrypt((char)0, inFIle, outFile, hexKey.ToString());

                if (res != 0)
                {
                    switch (res)
                    {

                        case 0: msg = "OK";
                            break;
                        case -2: msg = "Key must be in hexadecimal notation";
                            break;
                        case -3: msg = "key too long";
                            break;
                        case -4: msg = "The key length must be 32, 48 or 64 hexadecimal digits";
                            break;
                        case -5: msg = "The input file could not be opened";
                            break;
                        case -6: msg = "The output file could not be opened";
                            break;
                        case -7: msg = "Error reading from input file";
                            break;
                        case -8: msg = "Error reading from output file";
                            break;
                        default:
                            msg = string.Format("Unknown:{0}", res);
                            break;

                    }

                    auxMsg = string.Format("Error to Decrytp file: csSource {0}->{1}", inFIle, msg);

                    throw new Win32Exception(res, auxMsg);
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
