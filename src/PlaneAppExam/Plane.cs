﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneAppExam
{
    public class Plane
    {
        public string Model { get; set; }
        public double MaxRange { get; set; }
        public double CruiseSpeed { get; set; }

        public Plane(string model, double maxRange, double cruiseSpeed)
        {
            Model = model;
            MaxRange = maxRange;
            CruiseSpeed = cruiseSpeed;
        }
    }
}
