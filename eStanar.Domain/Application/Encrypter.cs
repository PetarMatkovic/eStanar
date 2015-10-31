using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eStanar.Domain.Application
{
    public static class Encrypter
    {
        #region Fields
        private const string passwordStr = "!#vbGt&6z1XyL";
        private const string saltStr = "Gtr47!3#1pn%S";
        #endregion

        #region Methods
        /// <summary>
        /// Encrypt string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string EncryptString(string inputString)
        {
            try
            {
                if (inputString != null)
                {
                    // First we need to turn the input string into a byte array. 
                    byte[] queryStringBytes = Encoding.UTF8.GetBytes(inputString);//Encoding.Unicode.GetBytes(queryString) ovo je izbacivalo pogrešku;

                    // Then, we need to turn the password into Key and IV. We are using salt to make it harder to guess our key
                    // using a dictionary attack - trying to guess a password by enumerating all possible words. 
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes(passwordStr, Encoding.UTF8.GetBytes(saltStr));

                    // Now get the key/IV and do the encryption using the function that accepts byte arrays. 
                    // Using PasswordDeriveBytes object we are first getting 32 bytes for the Key  (the default Rijndael key length is 256bit = 32bytes)
                    // and then 16 bytes for the IV. IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael. 
                    byte[] encryptedData = Encrypt(queryStringBytes,
                        pdb.GetBytes(32), pdb.GetBytes(16));

                    return Convert.ToBase64String(encryptedData);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            { }
        }

        public static string EncryptString(int inputValue)
        {
            return EncryptString(inputValue.ToString());
        }

        /// <summary>
        /// Decrypt string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string DecryptString(string inputString)
        {
            try
            {
                if (inputString != null)
                {
                    //Ova linija je obavezna! Ako uleti razmak moram ga pretvorit u + ili konverzija puca
                    inputString = CleanString(inputString);

                    // First we need to turn the input string into a byte array.
                    // We presume that Base64 encoding was used 
                    byte[] queryStringBytes = Convert.FromBase64String(inputString);

                    // Then, we need to turn the password into Key and IV. We are using salt to make it harder to guess our key
                    // using a dictionary attack - trying to guess a password by enumerating all possible words. 
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes(passwordStr, Encoding.UTF8.GetBytes(saltStr));

                    // Now get the key/IV and do the encryption using the function that accepts byte arrays. 
                    // Using PasswordDeriveBytes object we are first getting 32 bytes for the Key  (the default Rijndael key length is 256bit = 32bytes)
                    // and then 16 bytes for the IV. IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael. 
                    byte[] decryptedData = Decrypt(queryStringBytes,
                        pdb.GetBytes(32), pdb.GetBytes(16));


                    // Now we need to turn the resulting byte array into a string. A common mistake would be to use an Encoding class for that.
                    // It does not work because not all byte values can be represented by characters. 
                    // We are going to be using Base64 encoding that is designed exactly for what we are trying to do. 
                    return Encoding.UTF8.GetString(decryptedData);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Clean string when decrypting in case it contains space character
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private static string CleanString(string inputStr)
        {
            inputStr = inputStr.Replace(" ", "+");
            return inputStr;
        }

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="clearData"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static byte[] Encrypt(byte[] clearData, byte[] key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream memoryStream = new MemoryStream();

            //Create a symmetric algorithm. We are going to use Rijndael because it is strong 
            //and available on all platforms. 
            Rijndael cryptAlgorithm = Rijndael.Create();

            //Now set the key and the IV (nitialization Vector)
            cryptAlgorithm.Key = key;
            cryptAlgorithm.IV = IV;

            //Create a CryptoStream through which we are going to be pumping our data. 
            // CryptoStreamMode.Write means that we are going to be writing data to the stream  and the output will be written in the MemoryStream we have provided. 
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption 
            cryptoStream.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock).  This will tell it that we have done our encryption and there is no more data coming in, 
            // and it is now a good time to apply the padding and finalize the encryption process. 
            cryptoStream.Close();

            // Now get the encrypted data from the MemoryStream.
            byte[] encryptedData = memoryStream.ToArray();

            return encryptedData;
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="clearData"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] clearData, byte[] key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream memoryStream = new MemoryStream();

            //Create a symmetric algorithm. We are going to use Rijndael because it is strong 
            //and available on all platforms. 
            Rijndael cryptAlgorithm = Rijndael.Create();

            //Now set the key and the IV (nitialization Vector)
            cryptAlgorithm.Key = key;
            cryptAlgorithm.IV = IV;

            //Create a CryptoStream through which we are going to be pumping our data. 
            // CryptoStreamMode.Write means that we are going to be writing data to the stream  and the output will be written in the MemoryStream we have provided. 
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption 
            cryptoStream.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock).  This will tell it that we have done our encryption and there is no more data coming in, 
            // and it is now a good time to apply the padding and finalize the encryption process. 
            cryptoStream.Close();

            // Now get the decrypted data from the MemoryStream.
            byte[] decryptedData = memoryStream.ToArray();

            return decryptedData;
        }
        #endregion
    }
}
