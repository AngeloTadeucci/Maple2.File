using Maple2.File.Parser;
using Maple2.File.IO.Nif;
using Maple2.File.Parser.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Numerics;

namespace Maple2.File.Tests;

[TestClass]
public class NifParserTest {
    public NifParserTest() { }

    [TestMethod]
    public void TestLlidHash() {
        uint hash = LlidHash.Hash("/model/map/tria/cube/tr_floor_pillar_a01.nif");

        Assert.AreEqual(hash, 0xC4FF5AA2);
    }

    [TestMethod]
    public void TestNifParser() {
        var parser = new NifParser(TestUtils.ModelM2dReaders);
        ValidateNifMeshData(parser);
    }

    [TestMethod]
    public void TestNifParserKr() {
        var parser = new NifParser(TestUtilsKr.ModelM2dReaders);
        ValidateNifMeshData(parser);
    }

    private static void ValidateNifMeshData(NifParser parser) {
        foreach ((uint llid, string relpath, NifDocument document) in parser.Parse()) {
            try {
                document.Parse();
            } catch (Exception ex) {
                if (ex.InnerException is NifVersionNotSupportedException nifEx) {
                    // Maybe print unsupported nif versions here if you're the user. Nexon left in some Gamebryo stock assets that are <v30
                } else {
                    throw;
                }
            }

            List<NiPhysXProp> physXProps = document.PhysXProps;

            if (physXProps.Count == 0) {
                continue;
            }

            Assert.AreEqual(physXProps.Count, 1);

            bool meshFound = false;

            foreach (NiPhysXProp prop in physXProps) {
                if (prop.Snapshot is null) {
                    continue;
                }

                if (prop.Snapshot.Actors.Count == 0) {
                    continue;
                }

                foreach (NiPhysXActorDesc actor in prop.Snapshot.Actors) {
                    if (actor.ShapeDescriptions.Count == 0) {
                        continue;
                    }

                    foreach (NiPhysXShapeDesc shape in actor.ShapeDescriptions) {
                        if (shape.Mesh is null) {
                            continue;
                        }

                        meshFound = true;

                        Assert.IsTrue(shape.Mesh.MeshData.Length > 8); // more than nxs header

                        string headerPiece1 = Encoding.UTF8.GetString(shape.Mesh.MeshData, 0, 3);
                        string headerPiece2 = Encoding.UTF8.GetString(shape.Mesh.MeshData, 4, 4);

                        if (headerPiece1 != "NXS") {
                            throw new InvalidDataException($"Bad PhysX mesh data found in nif {relpath}");
                        }

                        Assert.AreEqual(headerPiece1, "NXS");

                        switch (headerPiece2) {
                            case "CVXM":
                                break;
                            case "MESH":
                                break;
                            case "CLTH":
                                throw new NotSupportedException($"Cloth mesh not supported! Found unsupported PhysX cloth mesh in nif {relpath}");
                            default:
                                throw new InvalidDataException($"Unknown PhysX nxs mesh type {headerPiece2} found in mesh data in {relpath}");
                        }

                        PhysXMesh mesh = new PhysXMesh(shape.Mesh.MeshData);

                        Assert.AreNotEqual(0, mesh.Vertices.Count);
                        Assert.AreNotEqual(0, mesh.Faces.Count);
                    }
                }
            }

            if (!meshFound) {
                continue;
            }
        }
    }

    private bool VectorNearlyEquals(Vector3 vec1, Vector3 vec2) {
        return Vector3.DistanceSquared(vec1, vec2) < 1e-5f; // Correct for floating point inaccuracies with some tolerance
    }

    private void TestMatrixData(byte[] matrixData, Vector3 testAxis1, Vector3 testAxis2, Vector3 testAxis3) {
        Stream matrixStream = new MemoryStream(matrixData);
        EndianReader reader = new EndianReader(matrixStream, false);

        Matrix4x4 result = reader.ReadAdjustedMatrix4x3();

        // Different axis on the matrix are placed on M[axisIndex][vectorAxis]
        Vector3 axis1 = new Vector3(result.M11, result.M12, result.M13);
        Vector3 axis2 = new Vector3(result.M21, result.M22, result.M23);
        Vector3 axis3 = new Vector3(result.M31, result.M32, result.M33);

        Assert.IsTrue(VectorNearlyEquals(axis1, testAxis1));
        Assert.IsTrue(VectorNearlyEquals(axis2, testAxis2));
        Assert.IsTrue(VectorNearlyEquals(axis3, testAxis3));
    }

    [TestMethod]
    public void TestMatrixParsing() {
        // Test matrix parsing using known good data from NIF files to ensure the correct major order is used
        byte[] matrixData1 = new byte[] {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f, 0x30, 0xbd, 0xbb, 0x33,
            0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x00, 0x00, 0x31, 0xbd, 0xbb, 0x33,
            0x30, 0xbd, 0xbb, 0x33, 0x31, 0xbd, 0xbb, 0xb3, 0x00, 0x00, 0x80, 0x3f,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        TestMatrixData(matrixData1,
            new Vector3(0, -1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 1));

        byte[] matrixData2 = new byte[] {
            0x00, 0x00, 0x80, 0x34, 0x00, 0x00, 0x00, 0xb3, 0x00, 0x00, 0x80, 0xbf,
            0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x80, 0x33, 0x00, 0x00, 0x80, 0xb4,
            0x00, 0x00, 0x00, 0x33, 0x00, 0x00, 0x80, 0x3f, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        TestMatrixData(matrixData2,
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 1),
            new Vector3(-1, 0, 0));

        byte[] matrixData3 = new byte[] {
            0x00, 0x00, 0x80, 0xbf, 0xd3, 0xbb, 0x8b, 0xb5, 0x00, 0x00, 0x00, 0x00,
            0xd3, 0xbb, 0x8b, 0x35, 0x00, 0x00, 0x80, 0xbf, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        TestMatrixData(matrixData3,
            new Vector3(-1, 0, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, 0, 1));

        byte[] matrixData4 = new byte[] {
            0xf0, 0x83, 0x84, 0x3e, 0xe9, 0x46, 0x77, 0xbf, 0x00, 0x00, 0x00, 0x00,
            0xe9, 0x46, 0x77, 0x3f, 0xf0, 0x83, 0x84, 0x3e, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3f,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        TestMatrixData(matrixData4,
            new Vector3(0.258819103f, 0.965925753f, 0),
            new Vector3(-0.965925753f, 0.258819103f, 0),
            new Vector3(0, 0, 1));
    }
}

