using System.Collections.Generic;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMapMetaData : I3DProxy {
        string ModelName => "MapMetaData";
        IDictionary<string, string> TargetEntity => new Dictionary<string, string>();
        string ProxyNifAsset => "urn:llid:0105d902-0000-0000-0000-000000000000";
    }
}
