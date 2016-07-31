# Helper [![Build status](https://ci.appveyor.com/api/projects/status/6p727frslp3x4vtp?svg=true)](https://ci.appveyor.com/project/mbarmawi/helper)

Helper is .net base library create to help developers on common and general tasks and be a helpful asst to any project.

Helper contane many function related to :
 * General numbers functions
 * Numbers conversion
 * Generate random numbers
 * Generate  fibonacci sequence
 * Shorthand string validation
 * Generate random string 
 * Json stringify,parse functions
 * Generate hashs like md5,Sha1,Sha256,Sha384,Sha512
 * Database connection test
 * Simple database layer
 * Get SystemInfo like OS,CPU,HDD ....
 
## Install
  ```
  * Add Helper.dll as reference to your project
  * Add using Helper; directive to your code
  ```

## How to use
 All the functions in Helper are static 
  ```cs
  int number = Nembers.ToInt("10");
  string  binaryNumer =  Numbers.ToBinary(number);
  string passwordHash = Cryptographyx.ToHash("123456", Algorithm.Md5); 
  string value = "Hello";
  bool result = Strings.IsValid(value);
  ```
 In addition [Sys](http://github.com/mbarmawi/sys) project build on top of helper and use SystemInfo functions.
 
##License
 Helper is freely distributable under the terms of the MIT license.
