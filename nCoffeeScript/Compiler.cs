using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using org.mozilla.javascript;

namespace nCoffeeScript
{
    public static class Compiler
    {
        private const string scriptFileName = "coffee-script.js";

        private static string coffeeScriptLibText;
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
        
        private static Scriptable parentScope;
        private static Scriptable ParentScope
        {
            get
            {
                if (parentScope == null)
                {
                    Context c = Context.enter();
                    
                    c.setOptimizationLevel(-1); // Rhino will freak out otherwise if bytecode limit is exceeded
                    parentScope = c.initStandardObjects();
                    c.evaluateString(parentScope, GetCoffeeScriptLib(), scriptFileName, 0, null);
                    
                    Context.exit();
                }

                return parentScope;
            }
        }

        public static void CompileFromFile(string filePath, bool noWrapOutput)
        {
            string textToCompile;
            using (StreamReader sr = new StreamReader(filePath))
            {
                textToCompile = sr.ReadToEnd();
            }
            
            // get the "name" of the coffeescript file and use that as the name for the compiled js
            FileInfo fi = new FileInfo(filePath);
            string compiledPath = Path.Combine(fi.DirectoryName, fi.Name.Replace(".coffee", ".js"));
            
            File.WriteAllText(compiledPath, 
                Compile(textToCompile, noWrapOutput));
        }

        public static string Compile(string pCoffeeScriptInput, bool noWrapOutput)
        {
            Context c = Context.enter();

            Scriptable compileScope = c.newObject(ParentScope);
            compileScope.setParentScope(ParentScope);
            compileScope.put("source", compileScope, pCoffeeScriptInput);

            string result = (string)c.evaluateString(compileScope, 
                "CoffeeScript.compile(source, {no_wrap: " + GetJSBool(noWrapOutput) + "});", 
                "nCoffeeScriptCompiler",
                0, 
                null);

            Context.exit();
            return result.Replace("\n", "\r\n");
        }

        // Helper function for converting .NET bool to our "injected" JS bool
        private static string GetJSBool(bool pBool)
        {
            if (pBool)
                return "true";
            else
                return "false";
        }
    }
}
