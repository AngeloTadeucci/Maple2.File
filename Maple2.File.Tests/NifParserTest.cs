using Maple2.File.Parser;
using Maple2.File.Parser.Nif;
using Maple2.File.Parser.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

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

        foreach ((uint llid, string relpath, List<NiPhysXProp> physXProps) in parser.Parse()) {
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
}
