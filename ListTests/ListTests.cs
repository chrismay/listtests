using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Framework;

namespace ConsoleApplication1
{
    class ListTests
    {
        static void Main(string[] args)
        {
            var testDll = args[0]; 
            CoreExtensions.Host.InitializeService();
            TestRunner runner = new SimpleTestRunner();
            var package = new TestPackage(testDll);
            runner.Load(package);
            var tests = runner.Test.Tests;
            foreach (TestNode test in tests)
            {
                ProcessTestNode(test);
            }    
        }

        static void ProcessTestNode(TestNode node)
        {
            if (node.TestType == "TestFixture")
            {
                if (node.Categories.Contains("Logistics"))
                {
                    var testName = node.TestName;

                    Console.Write(testName.Name + "\r\n");
                }
            }else if (node.TestType == "Namespace")
            {
                foreach (TestNode child in node.Tests)
                {
                    ProcessTestNode(child);
                }
            }else
            {
                Console.Write(node.TestType);
            }

        }
    }
}
