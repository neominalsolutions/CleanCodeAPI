﻿using AOPBussinessLayer.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPBussinessLayer.Services
{

  public class SampleService:ISample
  {
    [BenchMark]
    public void Execute()
    {

    }
  }
}
