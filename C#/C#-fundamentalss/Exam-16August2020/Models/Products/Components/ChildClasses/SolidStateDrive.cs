﻿namespace OnlineShop.Models.Products.Components.ChildClasses
{
    public class SolidStateDrive : Component
    {
        private const double OverallPerformanceMultiplier = 1.20;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * OverallPerformanceMultiplier;
    }
}