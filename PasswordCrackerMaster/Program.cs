﻿using System;

namespace PasswordCrackerMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Master master = new Master();
            master.Listen(6789);
        }
    }
}
