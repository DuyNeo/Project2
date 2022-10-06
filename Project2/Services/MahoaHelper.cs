using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


    public interface IMaHoaHelper
    {
        string MaHoa(string source);
    }
    public class MahoaHelper : IMaHoaHelper
    {
        public string MaHoa(string source)
        {
            string hash = "";
            using(var md5Hash = MD5.Create()) 
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); 
            }
            return hash;
        }
    }

