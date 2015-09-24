using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


public static class Extends
{
    public static void Write(this Stream s,Stream input)
    {
        input.Position = 0;

        //8K的缓存
        var bufferSize = 1024 * 8;
        var buffer = new byte[bufferSize];
        
        while(true)
        {
            int a = input.Read(buffer, 0, bufferSize);
            s.Write(buffer, 0, a);
            if (a < bufferSize)
                break;
        }
    }
}