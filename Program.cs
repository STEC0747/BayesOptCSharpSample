using System.Globalization;
using System;

using static SharpLearning.Optimization.Test.ObjectiveUtilities;
using SharpLearning.Optimization.ParameterSamplers;
using SharpLearning.Optimization;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // BayesianOptimizer_OptimizeBest_SingleParameter(2);
            BayesianOptimizer_OptimizeBest(2);
        }


        // public static OptimizerResult MinimizePow(double[] x)
        // {
        //     return new OptimizerResult(x, Math.Pow((x[0] - 2),2) );
        // }

        public static void BayesianOptimizer_OptimizeBest_SingleParameter(int? maxDegreeOfParallelism)
        {
            var parameters = new MinMaxParameterSpec[]
            {
                new MinMaxParameterSpec(-10.0, 10.0, Transform.Linear)
            };
            //var sut = CreateSut(maxDegreeOfParallelism, parameters);
            var sut = new BayesianOptimizer(parameters, iterations: 30, 
                                            randomStartingPointCount: 5, 
                                            functionEvaluationsPerIterationCount: 5, 
                                            randomSearchPointCount: 1000, 
                                            seed: 2, 
                                            maxDegreeOfParallelism: 3);

            //var actual = sut.OptimizeBest(MinimizeWeightFromHeight); 
            var actual = sut.OptimizeBest(MinimizePow); 
            Console.WriteLine("変数actual.Errorは{0}、変数ParameterSetは{1}", actual.Error, actual.ParameterSet[0]);


            // this.textBox1.Text = actual.Error.ToString();
            // this.textBox2.Text = actual.ParameterSet[0].ToString();
        }
        public static void BayesianOptimizer_OptimizeBest(int? maxDegreeOfParallelism)
        {
            var parameters = new MinMaxParameterSpec[]
            {
                new MinMaxParameterSpec(-10.0, 10.0, Transform.Linear),
                new MinMaxParameterSpec(-10.0, 10.0, Transform.Linear),
                new MinMaxParameterSpec(-10.0, 10.0, Transform.Linear)
            };
            var sut = CreateSut(maxDegreeOfParallelism, parameters);
            // var sut = new BayesianOptimizer(parameters, iterations: 30, 
                                            // randomStartingPointCount: 5, 
                                            // functionEvaluationsPerIterationCount: 5, 
                                            // randomSearchPointCount: 1000, 
                                            // seed: 2, 
                                            // maxDegreeOfParallelism: 3);

            var actual = sut.OptimizeBest(Minimize); 
            // var actual = sut.OptimizeBest(MinimizePow); 
            Console.WriteLine("変数actual.Errorは{0}、変数ParameterSet0は{1}、変数ParameterSet1は{2}", 
                              actual.Error, actual.ParameterSet[0], actual.ParameterSet[1]);


            // this.textBox1.Text = actual.Error.ToString();
            // this.textBox2.Text = actual.ParameterSet[0].ToString();
        }
        static BayesianOptimizer CreateSut(
                            int? maybeMaxDegreeOfParallelism,
                            MinMaxParameterSpec[] parameters)
        {
            const int DefaultMaxDegreeOfParallelism = -1;

            var maxDegreeOfParallelism = maybeMaxDegreeOfParallelism.HasValue ?
                maybeMaxDegreeOfParallelism.Value : DefaultMaxDegreeOfParallelism;

            var runParallel = maybeMaxDegreeOfParallelism.HasValue;

            var sut = new BayesianOptimizer(parameters,
                iterations: 30,
                randomStartingPointCount: 5,
                functionEvaluationsPerIterationCount: 5,
                randomSearchPointCount: 1000,
                seed: 42,
                runParallel: runParallel,
                maxDegreeOfParallelism: maxDegreeOfParallelism);

            return sut;
        }

    }
}
