using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace nCoffeeScript
{
    public static class Compiler
    {
        private const string scriptFileName = "coffee-script.js";
        private static string coffeeScriptLibText;

        public static void CompileFromFile(string filePath, bool noWrapOutput)
        {
            string textToCompile;
            using (StreamReader sr = new StreamReader(filePath))
            {
                textToCompile = sr.ReadToEnd();
            }
            
            // get the "name" of the coffeescript file and use that as the name for the compiled js
            FileInfo fi = new FileInfo(filePath);
            string compiledPath = fi.Directory + @"\" + fi.Name.Replace(".coffee", ".js");
            
            File.WriteAllText(compiledPath, Compile(textToCompile, noWrapOutput));
        }

        public static string Compile(string pCoffeeScriptInput, bool noWrapOutput)
        {
            // create a random file in the current dir so CScript can run it
            string tempScriptFileName = CreateTempScriptFile(pCoffeeScriptInput, noWrapOutput);

            // fire up CScript and redirect STDIN
            ProcessStartInfo info = new ProcessStartInfo("Cscript", tempScriptFileName + " //Nologo");
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            Process process = Process.Start(info);

            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // clean up
            File.Delete(tempScriptFileName);

            // give back the goods
            return result;
        }

        private static string CreateTempScriptFile(string pInput, bool noWrapOutput)
        {
            // we need to get a "javascript-readable" bool string value for the wrapping option
            string noWrapString = noWrapOutput.ToString().ToLower();

            StringBuilder contentsStringBuilder = new StringBuilder();
            contentsStringBuilder.Append(GetCoffeeScriptLib() + Environment.NewLine);
            contentsStringBuilder.Append("var coffee_to_compile = \"\\" + Environment.NewLine);
            contentsStringBuilder.Append(pInput.Replace("\r\n", "\\n\\" + Environment.NewLine));
            contentsStringBuilder.Append("\";" + Environment.NewLine + Environment.NewLine);
            contentsStringBuilder.Append("WScript.Echo(CoffeeScript.compile(coffee_to_compile, {no_wrap: " + noWrapString + "} ));");

            string filePath = Guid.NewGuid() + ".js";   // this should be unique enough
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(contentsStringBuilder.ToString());
            }
            return filePath;
        }

        private static string GetCoffeeScriptLib()
        {
            if (coffeeScriptLibText == null)
            {
                using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("nCoffeeScript." + scriptFileName))
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        coffeeScriptLibText = sr.ReadToEnd();
                    }
                }
            }
            return coffeeScriptLibText;
        }
    }
}
