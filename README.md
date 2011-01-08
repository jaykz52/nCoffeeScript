nCoffeeScript
=============

nCoffeeScript is a simple command-line compiler for [CoffeeScript](http://coffeescript.org/) for Windows environments written in .NET.

# Usage
nCoffeeScript allows you to compile individual CoffeeScript files into Javascript files:

    ncoffeescript.exe foo.coffee

Or, you can compile a whole directory of CoffeeScript files. The javascript output is placed in the same directory as the coffeescript files:

    ncoffeescript.exe C:\foo

By default, nCoffeeScript wraps the compiled javascript in a safety function to avoid polluting the global namespace. You can avoid the function wrapping by  using the "nowrap" command-line option:

    ncoffeescript.exe foo.coffee /nowrap

# Dependencies
nCoffeeScript requires the .NET Framework v2.0. The program uses Rhino (via IKVM.NET) to actually compile the coffeescript in a JS environment. These dependencies are located in the "lib" folder, so it should "just work."  To make ncoffeescript.exe more portable, these DLL dependencies could be installed in the GAC.

# Get the source
<https://github.com/jaykz52/nCoffeeScript>

# Issues/Feature Requests/Fan Mail
Go to <https://github.com/jaykz52/nCoffeeScript/issues> and let me know what doesn't work along with some repro steps. If you'd like to see a feature let me know; we might be able to work something out...

# License
Copyright (c) 2010 Jason Kozemczak <jason.kozemczak@gmail.com>

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.