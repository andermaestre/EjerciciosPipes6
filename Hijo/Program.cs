using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

namespace Hijo
{
    class Program
    {
        static void Main(string[] args)
        {
            int cont;
            int lim;
            using (AnonymousPipeClientStream pipe = new AnonymousPipeClientStream(PipeDirection.In, args[0]))
            {

                using (StreamReader sr = new StreamReader(pipe))
                {
                    cont = int.Parse(sr.ReadLine());
                    lim = int.Parse(sr.ReadLine());
                }
            }

            if (cont == 0)
            {
                using (NamedPipeClientStream pipa = new NamedPipeClientStream(".", "pepepipe", PipeDirection.InOut))
                {

                    using (StreamWriter sw = new StreamWriter(pipa))
                    {
                        using (StreamReader sr = new StreamReader(pipa))
                        {
                            pipa.Connect();

                            sw.AutoFlush = true;

                            do
                            {
                                lim--;

                                sw.WriteLine("ping");

                            } while (lim != 0);

                        }

                    }

                }
            }
            else
            {

            }






        }
    }
}