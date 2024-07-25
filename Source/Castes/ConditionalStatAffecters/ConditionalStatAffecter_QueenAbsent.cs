using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace GeneticCastes
{

    /// <summary>
    /// Checks if there is no queen on the map.
    /// </summary>
    public class ConditionalStatAffecter_QueenAbsent : ConditionalStatAffecter
    {
        public override string Label => (string)"StatsReport_QueenAbsent".Translate();

        public override bool Applies(StatRequest req)
        {
            if (req.Pawn == null || !req.Pawn.Spawned || req.Pawn.genes == null)
                return false;
            // If the pawn is not on Map (e.g. caravan), no mali 
            if (!HiveUtility.PawnIsOnHomeMap(req.Pawn))
                return false;

            if (req.Pawn.genes.HasActiveGene(GeneDefOf.genetic_castes_zealous_loyalty))
            {
                return HiveUtility.QueensOnMap() == 0;
            }

            return false;
        }
    }
}