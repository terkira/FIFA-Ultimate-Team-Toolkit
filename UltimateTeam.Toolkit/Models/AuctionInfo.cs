﻿using UltimateTeam.Toolkit.Extensions;

namespace UltimateTeam.Toolkit.Models
{
    public class AuctionInfo
    {
        public const uint MIN_BID = 150;

        public string BidState { get; set; }

        public uint BuyNowPrice { get; set; }

        public uint CurrentBid { get; set; }

        public int Expires { get; set; }

        public ItemData ItemData { get; set; }

        public uint Offers { get; set; }

        public string SellerEstablished { get; set; }

        public uint SellerId { get; set; }

        public string SellerName { get; set; }

        public uint StartingBid { get; set; }

        public long TradeId { get; set; }

        public string TradeState { get; set; }

        public bool? Watched { get; set; }

        public uint CalculateBid()
        {
            if (CurrentBid == 0)
                return StartingBid;
            else
                return CalculateNextBid(CurrentBid);
        }

        public static uint CalculateNextBid(uint currentBid)
        {
            if (currentBid == 0)
                return MIN_BID;

            if (currentBid < 1000)
                return currentBid + 50;

            if (currentBid < 10000)
                return currentBid + 100;

            if (currentBid < 50000)
                return currentBid + 250;

            if (currentBid < 100000)
                return currentBid + 500;

            return currentBid + 1000;
        }

        public long CalculateBaseId()
        {
            return ItemData.ResourceId.CalculateBaseId();
        }
    }
}