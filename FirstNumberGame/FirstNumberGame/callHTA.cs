using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FirstNumberGame
{
    class callHTA
    {
        static void Main(string[] args)
        {
            try
            {
                string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                Directory.CreateDirectory(tempDirectory);

                File.WriteAllText(tempDirectory + "\\" + "g1.hta", Properties.Resources.g1);

                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FirstNumberGame.Resources.bg.jpg");
                FileStream fileStream = new FileStream(tempDirectory + "\\" + "bg.jpg", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
                Process p = new Process();
                p.StartInfo.FileName = "mshta.exe";
                p.StartInfo.Arguments = tempDirectory + "\\" + "g1.hta";
                p.StartInfo.UseShellExecute = true;
                p.Start();
                p.WaitForExit();


                Directory.Delete(tempDirectory, true);
            }
            catch (Exception)
            {


            }




        }
    }
}
