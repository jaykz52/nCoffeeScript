nCoffeescript
=============

nCoffeeScript is a simple compiler for [CoffeeScript](http://coffeescript.org/) for Windows environments written in .NET.

# Usage
It allows you to compile individual CoffeeScript files into Javascript files:

    ncoffeescript.exe foo.coffee

Or, you can compile a whole directory of CoffeeScript files. The javascript output is placed same directory as the coffeescript files:

    ncoffeescript.exe C:\foo

By default, nCoffeeScript wraps the compiled javascript in a safety function to avoid polluting the global namespace. You can avoid this using the "nowrap" command-line option:

    ncoffeescript.exe foo.coffee /nowrap

# Dependencies
nCoffeeScript currently requires the .NET Framework v3.5. Since the compiler doesn't use any 3.5 features, I plan to target .NET 2.0 ASAP. nCoffeeScript also requires that the CScript scripting engine be installed on the system. CScript is standard on all modern MS operating systems. Additionally, nCoffeeScript requires write access to the directory it lives in.  This may change in the future, but for the time being, we'll just deal with it.

# Get the source
https://github.com/jaykz52/nCoffeeScript

# Issues/Feature Requests/Fan Mail
Go to https://github.com/jaykz52/nCoffeeScript/issues and let me know what doesn't work along with some repro steps. If you'd like to see a feature let me know; we might be able to work something out...

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