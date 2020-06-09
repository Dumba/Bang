using System;

namespace Bang.Backend.Database.Static
{
    [Flags]
    public enum ECharacter
    {
        bart_cassidy = 1,
        black_jack = 2,
        calamity_janet = 4,
        el_gringo = 8,
        jesse_jones = 16,
        jourdonnais = 32,
        kit_carlson = 64,
        lucky_duke = 128,
        paul_regret = 256,
        pedro_ramirez = 512,
        rose_doolan = 1024,
        sid_ketchum = 2048,
        slab_the_killer = 4096,
        suzy_lafayette = 8192,
        vulture_sam = 16384,
        willy_the_kid = 32768,
    }

    public static class ECharacterExtension
    {
        public static int GetHP(this ECharacter self)
        {
            switch (self)
            {
                case ECharacter.el_gringo:
                case ECharacter.paul_regret:
                    return 3;
                default:
                    return 4;
            }
        }
    }
}