# Genetic Castes

[![BuyMeACoffee](https://raw.githubusercontent.com/pachadotdev/buymeacoffee-badges/main/bmc-white.svg)](https://buymeacoffee.com/vegapnk)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This mod adds a caste-system like in insect-hives for Rimworld, based on genes and pre-defined xenotypes.
You can either use the Halamyr as provided, or define your own castes using `XML`. 

This is originally extracted from my (NSFW) Mod [RJW-Genes](https://github.com/vegapnk/RJW-Genes/) `v1.3.3`. 

## Features 

**Castes** 

There are four types of pawns: 

- Queens  (=any Pawn with a Queen-Gene)
- Drones  (=any Pawn with a  Drone-Gene)
- Workers (=any Pawn with a Worker-Gene)
- Others  (Non-Caste-Pawns)

**Caste Inheritance** 

The castes are determined at birth, 
either from `Biotech` Pregnancy or from `RJW-Egg` pregnancy. 
 
The following steps are considered when a baby is born:

```python
if (baby has queen parent):
    if (baby has a drone parent):
        Maybe Queen (always same as queen parent)
        Maybe Drone (always same as drone parent)
        Maybe Worker 
    else:
        Baby is always worker
else:
    normal rimworld or rjw birth
```

Only queens can initiate an caste-birth.
Children born from workers / drones that have no queen as a parent might inherit the xenotype or parts of it, but that follows *normal* Rimworld / RJW logic. 
The mechanisms added by this mod only apply for babys with 1 queen parent. 

*Workers* are not "Xenotypes* like the others, and the worker genes are added to a born baby later. They do not *replace* anything, they are just *on top*. 
This means that e.g. if you have Imps as your partners you can have a imp-worker as result. 

*Queens* can also be male. I just picked the name for fitting into the theme. 

**Configuration / Definition** 

There are 2 files that are necessary for a hive: 

`HiveOffspringChanceDef` looking like this 

```xml 
	<GeneticCastes.HiveOffspringChanceDef>
        <defName>genetic_castes_test_queen_offspring_chances</defName>
        <queenXenotype>genetic_castes_test_queen_xenotype</queenXenotype>

        <queenChance>0.02</queenChance>
        <droneChance>0.28</droneChance>
        <workerChance>0.7</workerChance>

	</GeneticCastes.HiveOffspringChanceDef>
```

Which specifies for one queen-xenotype the chances of a baby-queen, baby-drone or baby-worker. 

The second XML is `QueenWorkerMappingDefs` which looks like this: 

```xml

	<GeneticCastes.QueenWorkerMappingDef>
        <defName>genetic_castes_halamyr_queen_worker_mapping</defName>
        <queenXenotype>genetic_castes_halamyr_queen_xenotype</queenXenotype>
		<workerGenes>
			<li MayRequire="sarg.alphagenes" >AG_SmallerBodySize</li>
			<li>StrongStomach</li>
			<li MayRequire="sarg.alphagenes" >AG_EfficientMandibles</li>
			<li MayRequire="sarg.alphagenes" >AG_FasterAging</li>
			<li>PsychicAbility_Dull</li>
			<li>FireTerror</li>
			<li>Sterile</li>
			<li MayRequire="sarg.alphagenes" >AG_FormicAntennas</li>
			<li>Skin_DeepRed</li>
			<li>AptitudeTerrible_Intellectual</li>
			<li MayRequire="vegapnk.rjw-genes">rjw_genes_featureless_chest</li>
			<li>genetic_castes_worker</li>
			<li>genetic_castes_zealous_loyalty</li>
		</workerGenes>
	</GeneticCastes.QueenWorkerMappingDef>
```

It has a unique defname, refers to the queen-xenotype (must match exactly!) and then a list of all genes that should be added to a worker. 
You also see that I have `MayRequire`s there to account for different mod-sources of genes. 

**Planned / Thoughts** 

I'd actually love for other people to use this more as a framework. 
I think if I add too many xenotypes or stuff like that it will suck a bit for people to add, there are enough mods that add bloat.
So for now this is 1 scenario with 3 1/2 xenotypes. 

Maybe I want to have a second set of genes that has non-gendered names, i.E. not queen but "leader" or something like this. 
But it seems a bit like bloat, lets first see how people like things.

One thing I'd like to add is to pick up some other genes that have a form of pregnancy, e.g. the Vanilla Expanded Phytokin or Alpha Genes insect-genes. 
But for now this is early stage and I'd mostly like you peeps to test. 

**Troubleshooting** 

```
I put eggs into a breeder and they are not fertilized!!!
```

Yes, this can happen due to `Base-RJW` logic and is a common mistake. 
If the eggs are *too old* they can still be transplanted, but not fertilized anymore. 
As of 26-07-2024, eggs can only be fertilized before half of their gestation. 

This is also affected by your egg-pregnancy settings. 
The slower your egg pregnancy is, the easier eggs are to fertilize. 