using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.IO.Pipes;

namespace EjerciciosPipes6
{
    class Program
    {
        static void Main(string[] args)
        {
            int lim = 5;
            for (int i = 0; i < 2; i++)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                using (AnonymousPipeServerStream apcs = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
                {
                    using (StreamWriter sw = new StreamWriter(apcs))
                    {
                        Process p = new Process();
                        psi.FileName = "..\\..\\..\\Hijo\\bin\\Debug\\Hijo.exe";
                        psi.UseShellExecute = false;
                        psi.Arguments = apcs.GetClientHandleAsString();
                        p.StartInfo = psi;

                        p.Start();
                        sw.WriteLine(i);
                        sw.WriteLine(lim);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}