using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace nCoffeeScript
{
    class Program
    {
        // TODO: I need to handle when the compiler can't compile!!!
        // TODO: should we throw some sort of Dependency Exception early on if Cscript doesn't exist?
        static void Main(string[] args)
        {
            bool noWrap = false;

            // we need to loop through all of the args first to grab the "nowrap" arg
            foreach (string arg in args)
            {
                if (arg == "/nowrap")
                {
                    noWrap = true;
                    break;
                }
            }

            // now that we have the important options, let's roll
            foreach (string arg in args)
            {
                if (Directory.Exists(arg))
                {
                    // if we passed a directory, we'll compile each file and output it into a .js file in the directory
                    DirectoryInfo di = new DirectoryInfo(arg);
                    foreach (FileInfo fi in di.GetFiles("*.coffee"))
                        Compiler.CompileFromFile(fi.FullName, noWrap);
                }
                else if (File.Exists(arg))
                    Compiler.CompileFromFile(arg, noWrap);
            }
        }
    }
}
