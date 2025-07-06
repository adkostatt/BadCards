using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Extensions;
using UnityEngine;


namespace BadCards.Cards
{
    class BlockStepBack : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            block.forceToAdd = -10f;
            block.cdAdd = 0.25f;
            statModifiers.health = 1.2f;
#if DEBUG
            UnityEngine.Debug.Log($"[{BadCards.ModInitials}][Card] {GetTitle()} has been setup.");
#endif
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // Edits values on player when card is selected
#if DEBUG
            UnityEngine.Debug.Log($"[{BadCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
#endif
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            player.StopAllCoroutines();
#if DEBUG
            UnityEngine.Debug.Log($"[{BadCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
#endif
        }
        protected override string GetTitle()
        {
            return "BlockStepBack";
        }
        protected override string GetDescription()
        {
            return "Reverse block force";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+20%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf
                },

                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block cooldown",
                    amount = "+0.25s",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return BadCards.ModInitials;
        }
    }
}
