﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RallyeLecture
{
    public class Hash
    {
        private string Sha264(string passWord)
        {
            var message = Encoding.ASCII.GetBytes(passWord);
            SHA256Managed hashstring = new SHA256Managed();
            string hex = "";

            var hashValue = hashstring.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            return hex;
            }
        

        string GetMd5Hash(MD5 md5Hash, int input)
        {
            
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Convert.ToString(input)));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private string Salt(int id)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, id);

            }
        }
        

        public string GetHashPassword(string passWord, int id)
        {
            string getHashPass = Salt(id) + Sha264(passWord);
            return getHashPass;
        }

    }






}