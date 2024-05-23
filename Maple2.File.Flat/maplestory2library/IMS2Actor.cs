using System;
using System.Collections.Generic;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Actor : IActor, IMS2TextKeyCallback, IMS2Reaction {
        string ModelName => "MS2Actor";
        bool MinimapInVisible => true;
        bool PauseEnable => false;
        float PauseTime => 0;
        string PauseEffect => "";
        // Manually added
        [Obsolete("This property should not exist")]
        IDictionary<string, string> NpcList => new Dictionary<string, string>();
        [Obsolete("This property should not exist")]
        string ProxyNifAsset => "";
        [Obsolete("This property should not exist")]
        int SpawnPointID => 0;
        [Obsolete("This property should not exist")]
        float SpawnRadius => 0;
        [Obsolete("This property should not exist")]
        uint NpcCount => 0;
        [Obsolete("This property should not exist")]
        string reactableSequenceName => "0";
    }
}
