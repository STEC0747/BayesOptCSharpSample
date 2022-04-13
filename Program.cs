using System.Globalization;
using System;

// using static SharpLearning.Optimization.Test.ObjectiveUtilities;
// using SharpLearning.Optimization.ParameterSamplers;
using SharpLearning.Optimization;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BayesianOptimizer_OptimizeBest_SingleParameter();
        }
        public static void BayesianOptimizer_OptimizeBest_SingleParameter()
        {
            var parameters = new MinMaxParameterSpec[]{new MinMaxParameterSpec(-10.0, 10.0, Transform.Linear)};  // parameter space
            var Opt = new BayesianOptimizer(parameters, iterations: 30,randomStartingPointCount: 5,
                                            functionEvaluationsPerIterationCount: 5,randomSearchPointCount: 1000,
                                            seed: 2,maxDegreeOfParallelism: 3);
            var result = Opt.OptimizeBest(ObjectiveFunction); 
            Console.WriteLine("変数Errorは{0}、BestParameterは{1}", result.Error, result.ParameterSet[0]);
        }        
        public static OptimizerResult ObjectiveFunction(double[] parameter)
        {
            return new OptimizerResult(parameter, Math.Pow((parameter[0] - 2),2) );
        }
    }
}
