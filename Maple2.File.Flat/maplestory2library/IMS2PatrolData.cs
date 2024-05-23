using System.Collections.Generic;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PatrolData : IMapEntity {
        string ModelName => "MS2PatrolData";
        IDictionary<string, string> WayPoints => new Dictionary<string, string>();
        IDictionary<string, string> ApproachAnims => new Dictionary<string, string>();
        IDictionary<string, string> ArriveAnims => new Dictionary<string, string>();
        IDictionary<string, uint> ArriveAnimsTime => new Dictionary<string, uint>();
        bool IsAirWayPoint => false;
        uint PatrolSpeed => 0;
        bool IsLoop => true;
    }
}
