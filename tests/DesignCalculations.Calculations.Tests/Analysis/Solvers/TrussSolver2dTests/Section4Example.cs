using System.Collections.Generic;
using System.Linq;
using Jpp.DesignCalculations.Calculations.Analysis.Bars.Steel;
using NUnit.Framework;
using Jpp.DesignCalculations.Calculations.Analysis.Solvers;
using Jpp.DesignCalculations.Calculations.DataTypes;
using MathNet.Numerics.LinearAlgebra;

namespace Jpp.DesignCalculations.Calculations.Tests.Analysis.Solvers.TrussSolver2dTests
{
    /// <summary>
    /// Tests based on Worked Example, Chapter 4 of Matrix Analysis of Structures
    /// </summary>
    [TestFixture]
    public class Section4Example
    {
        [Test]
        public void VerifyNumberOfJoints()
        {
            TrussSolver2d solver = Build();
            var jointList = solver.BuildJointList();
            Assert.AreEqual(6, jointList.Count());
        }

        [Test]
        public void VerifyJointStructure()
        {
            TrussSolver2d solver = Build();
            var joints = solver.BuildJointList();
            Matrix<double> jointStructure = solver.BuildJointStructure(joints);

            Matrix<double> expected = Matrix<double>.Build.DenseOfArray(new[,] {
                { 0.0,  0.0},
                { 288.0,  0.0},
                { 576.0,  0.0},
                { 864.0,  0.0},
                { 288.0,  216.0},
                { 576.0,  216.0}
            });

            Assert.AreEqual(expected, jointStructure);
        }

        [Test]
        public void VerifySupportStructure()
        {
            TrussSolver2d solver = Build();
            var joints = solver.BuildJointList();
            Matrix<double> supportStructure = solver.BuildSupportStructure(joints);

            Matrix<double> expected = Matrix<double>.Build.DenseOfArray(new[,] {
                { 0.0,  1.0, 1.0},
                { 2.0,  0.0, 1.0},
                { 3.0,  0.0, 1.0}
            });

            Assert.AreEqual(expected, supportStructure);
        }

        [Test]
        public void VerifyMemberStructure()
        {
            TrussSolver2d solver = Build();
            var joints = solver.BuildJointList();
            Matrix<double> memberStructure = solver.BuildMemberStructure(joints);

            Matrix<double> expected = Matrix<double>.Build.DenseOfArray(new[,] {
                { 0.0,  1.0, 29000.0, 8.0},
                { 1.0,  2.0, 29000.0, 8.0},
                { 2.0,  3.0, 10000.0, 16.0},
                { 4.0,  5.0, 29000.0, 8.0},
                { 1.0,  4.0, 29000.0, 8.0},
                { 2.0,  5.0, 29000.0, 8.0},
                { 0.0,  4.0, 29000.0, 12.0},
                { 1.0,  5.0, 29000.0, 12.0},
                { 2.0,  4.0, 29000.0, 12.0},
                { 3.0,  5.0, 10000.0, 16.0}
            });

            Assert.AreEqual(expected, memberStructure);
        }

        [Test]
        public void VerifyCoordinateNumberStructure()
        {
            TrussSolver2d solver = Build();
            var joints = solver.BuildJointList();
            Matrix<double> supportStructure = solver.BuildSupportStructure(joints);
            Vector<double> coordinateNumberStructure = solver.BuildCoordinateNumberStructure(joints, supportStructure);

            Vector<double> expected = Vector<double>.Build.DenseOfArray(new[]
            {
                8.0,
                9.0,
                0.0,
                1.0,
                2.0,
                10.0,
                3.0,
                11.0,
                4.0,
                5.0,
                6.0,
                7.0
            });

            Assert.AreEqual(expected, coordinateNumberStructure);
        }

        [Test]
        public void VerifyLoadVector()
        {
            TrussSolver2d solver = Build();
            IEnumerable<Point3d> joints = solver.BuildJointList();
            Matrix<double> supportStructure = solver.BuildSupportStructure(joints);
            Vector<double> coordinateStructure = solver.BuildCoordinateNumberStructure(joints, supportStructure);

            (Vector<double> loadJoints, Matrix<double> loadMagnitude) = solver.BuildLoadStructures(joints);
            Vector<double> loadStructure = solver.BuildLoadVector(joints, loadJoints, loadMagnitude, coordinateStructure);

            Vector<double> expected = Vector<double>.Build.DenseOfArray(new[]
            {
                0.0,
                -75.0,
                0.0,
                0.0,
                25.0,
                0.0,
                0.0,
                -60.0
            });

            Assert.AreEqual(expected, loadStructure);
        }

        [Test]
        public void VerifyDisplacements()
        {
            TrussSolver2d solver = Build();

            IEnumerable<Point3d> joints = solver.BuildJointList();
            Matrix<double> jointStructure = solver.BuildJointStructure(joints);
            Matrix<double> supportStructure = solver.BuildSupportStructure(joints);
            Matrix<double> memberStructure = solver.BuildMemberStructure(joints);
            Vector<double> coordinateStructure = solver.BuildCoordinateNumberStructure(joints, supportStructure);
            (Vector<double> loadJoints, Matrix<double> loadMagnitude) = solver.BuildLoadStructures(joints);
            Vector<double> loadStructure = solver.BuildLoadVector(joints, loadJoints, loadMagnitude, coordinateStructure); //Condense with previous line?
            Matrix<double> stiffnessMatrixStructure = solver.BuildStiffnessMatrix(joints, memberStructure, jointStructure, coordinateStructure);
            Vector<double> displacements = stiffnessMatrixStructure.Solve(loadStructure);

            IEnumerable<JointDisplacement> jointDisplacements = solver.ExtractDisplacements(joints, displacements, coordinateStructure);
            List<JointDisplacement> expected = new List<JointDisplacement>()
            {
                new JointDisplacement()
                {
                    X = 0,
                    Y = 0
                },
                new JointDisplacement()
                {
                    X = 0.074568,
                    Y = -0.20253
                },
                new JointDisplacement()
                {
                    X = 0.11362,
                    Y = 0
                },
                new JointDisplacement()
                {
                    X = 0.10487,
                    Y = 0
                },
                new JointDisplacement()
                {
                    X = 0.057823,
                    Y = -0.15268
                },
                new JointDisplacement()
                {
                    X = 0.028344,
                    Y = -0.079235
                },
            };
        }

        private TrussSolver2d Build()
        {
            TrussSolver2d solver = new TrussSolver2d();
            //Bar 1
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(0,0,0),
                EndPoint = new Point3d(288,0,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 8}
            });
            //Bar 2
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(288,0,0),
                EndPoint = new Point3d(576,0,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 8}
            });
            //Bar 3
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(576,0,0),
                EndPoint = new Point3d(864,0,0),
                Material = new Material() { YoungsModulus = 10000},
                CrossSection = new CrossSection() { Area = 16}
            });
            //Bar 4
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(288,216,0),
                EndPoint = new Point3d(576,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 8}
            });
            //Bar 5
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(288,0,0),
                EndPoint = new Point3d(288,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 8}
            });
            //Bar 6
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(576,0,0),
                EndPoint = new Point3d(576,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 8}
            });
            //Bar 7
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(0,0,0),
                EndPoint = new Point3d(288,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 12}
            });
            //Bar 8
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(288,0,0),
                EndPoint = new Point3d(576,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 12}
            });
            //Bar 9
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(576,0,0),
                EndPoint = new Point3d(288,216,0),
                Material = new Material() { YoungsModulus = 29000},
                CrossSection = new CrossSection() { Area = 12}
            });
            //Bar 10
            solver.Bars.Add(new SteelBar()
            {
                StartPoint = new Point3d(864,0,0),
                EndPoint = new Point3d(576,216,0),
                Material = new Material() { YoungsModulus = 10000},
                CrossSection = new CrossSection() { Area = 16}
            });

            //Supports
            solver.Supports.Add(new Support()
            {
                Location = new Point3d(0,0,0),
                Restraint = JointRestraint.Pinned
            });
            solver.Supports.Add(new Support()
            {
                Location = new Point3d(576,0,0),
                Restraint = JointRestraint.RollerX
            });
            solver.Supports.Add(new Support()
            {
                Location = new Point3d(864,0,0),
                Restraint = JointRestraint.RollerX
            });

            //Loads
            solver.Loads.Add(new PointLoad()
            {
                Location = new Point3d(288,0,0),
                XForce = 0,
                YForce = -75
            });
            solver.Loads.Add(new PointLoad()
            {
                Location = new Point3d(288,216,0),
                XForce = 25,
                YForce = 0
            });
            solver.Loads.Add(new PointLoad()
            {
                Location = new Point3d(576,216,0),
                XForce = 0,
                YForce = -60
            });

            return solver;
        }
    }
}

